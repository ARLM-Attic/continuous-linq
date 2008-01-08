using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.Specialized;

namespace ContinuousLinq
{
    /// We want to arrange things so that when the output collection of
    /// a CLINQ chain gets dropped, all the intermediate adapters and
    /// collections also get dropped.  So we use weak event listeners.
    /// But we don't want the intermediate stuff to be dropped too early,
    /// so we need hard links back from the output collection to its
    /// adapter (which already has a hard link to its input collection).
    /// This hard link is the collection's SourceAdapter, which is also
    /// used for other purposes.
    internal abstract class ViewAdapter<Tin, Tout>
        where Tin : IEquatable<Tin>, INotifyPropertyChanged
    {
        protected InputCollectionWrapper<Tin> _input;
        protected ContinuousCollection<Tout> _output;
        private readonly NotifyCollectionChangedEventHandler _collectionChangedDelegate;
        private readonly PropertyChangedEventHandler _propertyChangedDelegate;
        private readonly Dictionary<Tin, WeakPropertyChangedHandler> _handlerMap = 
            new Dictionary<Tin, WeakPropertyChangedHandler>();

        public ViewAdapter(InputCollectionWrapper<Tin> input,
            ContinuousCollection<Tout> output)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            if (output == null)
                throw new ArgumentNullException("output");

            _input = input;
            _output = output;

            output.SourceAdapter = this;
            // Must be referenced by this instance:
            _collectionChangedDelegate = delegate(object sender, NotifyCollectionChangedEventArgs args)
                                             {
                                                 OnInputCollectionChanged(args);
                                             };
            _propertyChangedDelegate = delegate(object sender, PropertyChangedEventArgs args)
                                           {
                                               OnCollectionItemPropertyChanged((Tin)sender, args.PropertyName);
                                           };
            new WeakCollectionChangedHandler(_input.InnerAsNotifier, _collectionChangedDelegate);

            if (input.InnerAsList != null)
            {
                foreach (Tin item in input.InnerAsList)
                {
                    SubscribeToItemNoCheck(item);
                }
            }
        }

        /// <summary>
        /// Blindly subscribes to change events fired by the input item using a weak event handler
        /// </summary>
        /// <param name="item"></param>
        private void SubscribeToItemNoCheck(Tin item)
        {
            _handlerMap[item] = new WeakPropertyChangedHandler((INotifyPropertyChanged)item, _propertyChangedDelegate);
        }

        /// <summary>
        /// Subscribes to change events fired by the input item using a weak event handler, 
        /// only if the item has not been added to the handler map yet.
        /// </summary>
        /// <param name="item"></param>
        protected void SubscribeToItem(Tin item)
        {
            if (_handlerMap.ContainsKey(item) == false)
            {
                SubscribeToItemNoCheck(item);
            }
        }


        /// <summary>
        /// Unplugs all change event monitors (weak) from the indicated item.
        /// </summary>
        /// <param name="item"></param>
        protected void UnsubscribeFromItem(Tin item)
        {
            WeakPropertyChangedHandler handler;
            if (_handlerMap.TryGetValue(item, out handler))
            {
                handler.Detach();
                _handlerMap.Remove(item);
            }
        }

        /// <summary>
        /// A pointer to the collection to which this adapter is listening
        /// </summary>
        internal InputCollectionWrapper<Tin> InputCollection
        {
            get { return _input; }
        }

        /// <summary>
        /// A pointer to the collection to which all changes made by this adapter are
        /// propagated
        /// </summary>
        internal ContinuousCollection<Tout> OutputCollection
        {
            get { return _output; }
        }

        /// <summary>
        /// Defined in derived types
        /// </summary>
        /// <param name="item"></param>
        /// <param name="propertyName"></param>
        protected abstract void OnCollectionItemPropertyChanged(Tin item, string propertyName);

        /// <summary>
        /// Defined by derived types to respond to the event in which an item in the source collection
        /// is added.
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="index"></param>
        protected abstract void AddItem(Tin newItem, int index);

        /// <summary>
        /// Defined by derived types to respond to the event
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        protected abstract bool RemoveItem(Tin newItem, int index);

        /// <summary>
        /// Base actions to take place when the collection being monitored notifies the adapter
        /// of a change. This method calls AddItem and RemoveItem, which are defined by the derived
        /// types for cleanliness.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnInputCollectionChanged(NotifyCollectionChangedEventArgs e) {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                RemoveItem((Tin)e.OldItems[0], e.OldStartingIndex);
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                AddItem((Tin)e.NewItems[0], e.NewStartingIndex);
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                if (RemoveItem((Tin)e.OldItems[0], e.OldStartingIndex))
                {
                    AddItem((Tin)e.NewItems[0], e.NewStartingIndex);
                }
            }
        }

        
    }
}
