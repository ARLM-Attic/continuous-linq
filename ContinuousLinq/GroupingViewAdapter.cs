using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Threading;

namespace ContinuousLinq
{
    /// <summary>
    /// The GroupingViewAdapter is a view adapter that takes an input collection and applies
    /// a grouping algorithm to it (defined by the group-by clause in the original LINQ query).
    /// The results of the grouping clause are created in an output collection which we
    /// require to be a ContinuousCollection of GroupedContinuousCollection instances.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TElement"></typeparam>
    internal sealed class GroupingViewAdapter<TSource, TKey, TElement> :
        ViewAdapter<TSource, GroupedContinuousCollection<TKey, TElement>>
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
            
    {
        private delegate GroupedContinuousCollection<TKey, TElement> CreateGroupDelegate(TKey theKey, IEqualityComparer<TKey> comparer);

        private readonly Func<TSource, TKey> _keySelector;
        private readonly Func<TSource, TElement> _elementSelector;
        private readonly IEqualityComparer<TKey> _comparer;
        private readonly Dispatcher _dispatcher;
        private readonly Dictionary<TKey, GroupedContinuousCollection<TKey, TElement>> _groupMap = new Dictionary<TKey, GroupedContinuousCollection<TKey, TElement>>();

        public GroupingViewAdapter(
            InputCollectionWrapper<TSource> source,
            ContinuousCollection<GroupedContinuousCollection<TKey, TElement>> output,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer)
            : base(source, output)
        {
            if (elementSelector == null)
                throw new ArgumentNullException("elementSelector");
            _keySelector = keySelector;
            _elementSelector = elementSelector;
            if (comparer == null)
            {
                comparer = EqualityComparer<TKey>.Default;
            }
            _comparer = comparer;
            _dispatcher = Dispatcher.CurrentDispatcher;

            foreach (TSource item in source.InnerAsList)
            {
                AddItem(item);
            }
        }

        private void AddItem(TSource item)
        {
            TKey theKey = _keySelector(item);
            GroupedContinuousCollection<TKey, TElement> outputGroup;
            if (_groupMap.TryGetValue(theKey, out outputGroup))
            {
                // new item belongs in this group
                outputGroup.Add(_elementSelector(item));
            }
            else
            {
                // item belongs in a new group
                GroupedContinuousCollection<TKey, TElement> newGroup;
                if (_dispatcher.CheckAccess())
                {
                    newGroup = CreateGroup(theKey, _comparer);
                }
                else
                {
                    newGroup = (GroupedContinuousCollection<TKey, TElement>)_dispatcher.Invoke(
                                                                                DispatcherPriority.Normal,
                                                                                new CreateGroupDelegate(CreateGroup), theKey, _comparer);
                }
                // Maybe later use output's dispatch priority?
                newGroup.Add(_elementSelector(item));
                this.OutputCollection.Add(newGroup);
                _groupMap[theKey] = newGroup;
            }
        }

        private static GroupedContinuousCollection<TKey, TElement> CreateGroup(TKey theKey, IEqualityComparer<TKey> comparer)
        {
            return new GroupedContinuousCollection<TKey, TElement>(theKey, comparer);
        }

        protected override void AddItem(TSource item, int index)
        {
            SubscribeToItem(item);
            AddItem(item);
        }

        private void PostRemove(GroupedContinuousCollection<TKey, TElement> group)
        {
            if (group.Count == 0)
            {
                this.OutputCollection.Remove(group);
                _groupMap.Remove(group.Key);
            }
        }

        protected override bool RemoveItem(TSource item, int index)
        {
            UnsubscribeFromItem(item);
            bool hadIt = false;
            // Remove the item from the appropriate group.
            // Do it the hard way in case a property change was missed.
            TElement element = _elementSelector(item);
            foreach (GroupedContinuousCollection<TKey, TElement> scanGroup in this.OutputCollection)
            {
                if (scanGroup.Remove(element))
                {
                    PostRemove(scanGroup);
                    hadIt = true;
                    break;
                }
            }
            return hadIt;
        }

        protected override void OnCollectionItemPropertyChanged(TSource item, string propertyName)
        {
            //  Trace.WriteLine("[GVA] Property Changed.");
            TKey theKey = _keySelector(item);
            TElement element = _elementSelector(item);
            foreach (GroupedContinuousCollection<TKey, TElement> oldGroup in this.OutputCollection)
            {
                if (oldGroup.Contains(element))
                {
                    if (oldGroup.Key.Equals(theKey) == false)
                    {
                        oldGroup.Remove(element);
                        PostRemove(oldGroup);
                        AddItem(item);
                    }
                    break;
                }
            }
        }
    }
}
