using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.Specialized;

namespace ContinuousLinq
{
    // So here's the lowdown:
    // We want to arrange things so that when the output collection of
    // a CLINQ chain gets dropped, all the intermediate adapters and
    // collections also get dropped.  So we use weak event listeners.
    // But we don't want the intermediate stuff to be dropped too early,
    // so we need hard links back from the output collection to its
    // adapter (which already has a hard link to its input collection).
    // This hard link is the collection's SourceAdapter, which is also
    // used for other purposes.
    internal abstract class ViewAdapter<Tin, Tout>
        where Tin : IEquatable<Tin>, INotifyPropertyChanged
    {
        protected InputCollectionWrapper<Tin> _input;
        protected ContinuousCollection<Tout> _output;
        private readonly NotifyCollectionChangedEventHandler _collectionChangedDelegate;
        private readonly PropertyChangedEventHandler _propertyChangedDelegate;
        private readonly Dictionary<Tin, WeakPropertyChangedHandler> _handlerMap = new Dictionary<Tin, WeakPropertyChangedHandler>();

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

        private void SubscribeToItemNoCheck(Tin item)
        {
            _handlerMap[item] = new WeakPropertyChangedHandler((INotifyPropertyChanged)item, _propertyChangedDelegate);
        }

        protected void SubscribeToItem(Tin item)
        {
            if (_handlerMap.ContainsKey(item) == false)
            {
                SubscribeToItemNoCheck(item);
            }
        }

        protected void UnsubscribeFromItem(Tin item)
        {
            WeakPropertyChangedHandler handler;
            if (_handlerMap.TryGetValue(item, out handler))
            {
                handler.Detach();
                _handlerMap.Remove(item);
            }
        }

        internal InputCollectionWrapper<Tin> InputCollection
        {
            get { return _input; }
        }

        internal ContinuousCollection<Tout> OutputCollection
        {
            get { return _output; }
        }

        protected abstract void OnCollectionItemPropertyChanged(Tin item, string propertyName);
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
        protected abstract void AddItem(Tin newItem, int index);
        protected abstract bool RemoveItem(Tin newItem, int index);
    }
}
