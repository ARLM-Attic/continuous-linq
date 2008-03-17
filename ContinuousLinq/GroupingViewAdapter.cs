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
        private readonly Func<TSource, TKey> _keySelector;
        private readonly Func<TSource, TElement> _elementSelector;
        private readonly IEqualityComparer<TKey> _comparer;
        private readonly Dictionary<TKey, GroupedContinuousCollection<TKey, TElement>> _groupMap = new Dictionary<TKey, GroupedContinuousCollection<TKey, TElement>>();

        public GroupingViewAdapter(
            InputCollectionWrapper<TSource> source,
            ReadOnlyContinuousCollection<GroupedContinuousCollection<TKey, TElement>> output,
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

            foreach (TSource item in this.InputCollection)
            {
                AddItem(item);
            }
        }

        private void AddItem(TSource item)
        {
            TKey theKey = _keySelector(item);
            GroupedContinuousCollection<TKey, TElement> outputGroup;
            if (_groupMap.TryGetValue(theKey, out outputGroup) == false)
            {
                // item belongs in a new group
                outputGroup = new GroupedContinuousCollection<TKey, TElement>(theKey, _comparer);
                // Maybe later use output's dispatch priority?
                this.OutputCollection.Add(outputGroup);
                _groupMap[theKey] = outputGroup;
            }
            try
            {
                outputGroup.IsSealed = false;
                outputGroup.Add(_elementSelector(item));
            }
            finally
            {
                outputGroup.IsSealed = true;                
            }
        }

        protected override void AddItem(TSource item, int index)
        {
            SubscribeToItem(item);
            AddItem(item);
        }

        private bool RemoveFrom(TElement element, GroupedContinuousCollection<TKey, TElement> group)
        {
            bool ret;
            try
            {
                group.IsSealed = false;
                ret = group.Remove(element);
            }
            finally
            {
                group.IsSealed = true;
            }
            if (group.Count == 0)
            {
                this.OutputCollection.Remove(group);
                _groupMap.Remove(group.Key);
            }
            return ret;
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
                if (RemoveFrom(element, scanGroup))
                {
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
                        RemoveFrom(element, oldGroup);
                        AddItem(item);
                    }
                    break;
                }
            }
        }
    }
}
