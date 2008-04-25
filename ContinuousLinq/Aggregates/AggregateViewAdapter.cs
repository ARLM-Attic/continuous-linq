using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;
using System;

namespace ContinuousLinq.Aggregates
{
    public abstract class AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        private readonly InputCollectionWrapper<T> _input;
        private readonly NotifyCollectionChangedEventHandler _collectionChangedDelegate;
        private readonly PropertyChangedEventHandler _propertyChangedDelegate;
        private readonly Dictionary<T, WeakPropertyChangedHandler> _handlerMap =
            new Dictionary<T, WeakPropertyChangedHandler>();        

        protected AggregateViewAdapter(ObservableCollection<T> input) :
            this(new InputCollectionWrapper<T>(input))
        {
        }

        protected AggregateViewAdapter(ReadOnlyObservableCollection<T> input) : 
            this(new InputCollectionWrapper<T>(input))
        {
        }

        private AggregateViewAdapter(InputCollectionWrapper<T> input)
        {
            _input = input;
            
           _collectionChangedDelegate = 
               delegate(object sender, NotifyCollectionChangedEventArgs args)
           {
               OnInputCollectionChanged(args);
           };

            _propertyChangedDelegate = ((sender, e) => ReAggregate());

            new WeakCollectionChangedHandler(input.InnerAsNotifier, _collectionChangedDelegate);

            foreach (T item in this.InputCollection)
            {
                SubscribeToItem(item);
            }
            // Subclasses must call ReAggregate here!!!
        }

        protected IList<T> Input
        {
            get { return _input.InnerAsList; }
        }

        protected void SubscribeToItem(T item)
        {
            if (_handlerMap.ContainsKey(item) == false)
            {
                _handlerMap[item] = new WeakPropertyChangedHandler(item, _propertyChangedDelegate);
            }
        }

        protected void UnsubscribeFromItem(T item)
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
        protected IList<T> InputCollection
        {
            get { return _input.InnerAsList; }
        }

        void OnInputCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("[AVA] Input changed...");
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                    UnsubscribeFromItem((T) e.OldItems[0]);
                    break;
                case NotifyCollectionChangedAction.Add:
                    SubscribeToItem((T) e.NewItems[0]);
                    break;
                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Move:
                    UnsubscribeFromItem((T) e.OldItems[0]);
                    SubscribeToItem((T) e.NewItems[0]);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    foreach (T item in _input.InnerAsList)
                    {
                        UnsubscribeFromItem(item);
                    }
                    break;
            }
            ReAggregate();
        }

        protected void SetCurrentValue<U>(ContinuousValue<U> cv, U newValue)
        {
            cv.CurrentValue = newValue;
        }

        protected void SetSourceAdapter<U>(ContinuousValue<U> output, object adapter)
        {
            output.SourceAdapter = adapter;
        }

        protected abstract void ReAggregate();
    }
}
