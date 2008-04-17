using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ContinuousLinq.Aggregates
{
    public class AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        protected ObservableCollection<T> _input;
        private readonly NotifyCollectionChangedEventHandler _collectionChangedDelegate;
        private readonly PropertyChangedEventHandler _propertyChangedDelegate;
        private readonly Dictionary<T, WeakPropertyChangedHandler> _handlerMap =
            new Dictionary<T, WeakPropertyChangedHandler>();

        public AggregateViewAdapter(ObservableCollection<T> input)
        {
            _input = input;

            _collectionChangedDelegate = delegate(object sender, NotifyCollectionChangedEventArgs args)
            {
                OnInputCollectionChanged(args);
            };
            _propertyChangedDelegate = delegate(object sender, PropertyChangedEventArgs args)
            {
                OnCollectionItemPropertyChanged((T)sender, args.PropertyName);
            };

            new WeakCollectionChangedHandler(_input, _collectionChangedDelegate);

            foreach (T item in input)
            {
                SubscribeToItemNoCheck(item);
            }             
        }        

        protected void SubscribeToItem(T item)
        {
            if (_handlerMap.ContainsKey(item) == false)
            {
                SubscribeToItemNoCheck(item);
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

        private void SubscribeToItemNoCheck(T item)
        {
            _handlerMap[item] = 
                new WeakPropertyChangedHandler((INotifyPropertyChanged)item, _propertyChangedDelegate);
        }

        void OnInputCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                UnsubscribeFromItem((T)e.OldItems[0]);
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                SubscribeToItem((T)e.NewItems[0]);
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                UnsubscribeFromItem((T)e.OldItems[0]);
                SubscribeToItem((T)e.NewItems[0]);                
            }
            ReAggregate();
        }

        void OnCollectionItemPropertyChanged(T item, string propertyName)
        {
            ReAggregate();
        }

        protected virtual void ReAggregate() { }
    }
}
