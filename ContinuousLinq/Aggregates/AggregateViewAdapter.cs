using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;

namespace ContinuousLinq.Aggregates
{
    public abstract class AggregateViewAdapter<Tinput, Toutput> where Tinput : INotifyPropertyChanged
    {
        private readonly InputCollectionWrapper<Tinput> _input;
        private readonly NotifyCollectionChangedEventHandler _collectionChangedDelegate;
        private readonly PropertyChangedEventHandler _propertyChangedDelegate;
        private readonly Dictionary<Tinput, WeakPropertyChangedHandler> _handlerMap =
            new Dictionary<Tinput, WeakPropertyChangedHandler>();
        private readonly ContinuousValue<Toutput> _output = new ContinuousValue<Toutput>();

        protected AggregateViewAdapter(ObservableCollection<Tinput> input) :
            this(new InputCollectionWrapper<Tinput>(input))
        {
        }

        protected AggregateViewAdapter(ReadOnlyObservableCollection<Tinput> input) :
            this(new InputCollectionWrapper<Tinput>(input))
        {
        }

        private AggregateViewAdapter(InputCollectionWrapper<Tinput> input)
        {
            _input = input;
            _output.SourceAdapter = this;

            _collectionChangedDelegate =
                delegate(object sender, NotifyCollectionChangedEventArgs args)
                {
                    OnInputCollectionChanged(args);
                };

            _propertyChangedDelegate = ((sender, e) => ReAggregate());

            new WeakCollectionChangedHandler(input.InnerAsNotifier, _collectionChangedDelegate);

            foreach (Tinput item in this.InputCollection)
            {
                SubscribeToItem(item);
            }
            // Subclasses must call ReAggregate here!!!
        }

        protected IList<Tinput> Input
        {
            get { return _input.InnerAsList; }
        }

        protected void SubscribeToItem(Tinput item)
        {
            if (_handlerMap.ContainsKey(item) == false)
            {
                _handlerMap[item] = new WeakPropertyChangedHandler(item, _propertyChangedDelegate);
            }
        }

        protected void UnsubscribeFromItem(Tinput item)
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
        protected IList<Tinput> InputCollection
        {
            get { return _input.InnerAsList; }
        }

        void OnInputCollectionChanged(NotifyCollectionChangedEventArgs e)
        {            
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                    UnsubscribeFromItem((Tinput)e.OldItems[0]);
                    break;
                case NotifyCollectionChangedAction.Add:
                    SubscribeToItem((Tinput)e.NewItems[0]);
                    break;
                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Move:
                    UnsubscribeFromItem((Tinput)e.OldItems[0]);
                    SubscribeToItem((Tinput)e.NewItems[0]);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    foreach (Tinput item in _input.InnerAsList)
                    {
                        UnsubscribeFromItem(item);
                    }
                    break;
            }
            ReAggregate();
        }

        public ContinuousValue<Toutput> Value
        {
            get { return _output; }
        }

        protected void SetCurrentValue(Toutput newvalue)
        {
            _output.CurrentValue = newvalue;
        }

        protected void SetCurrentValueToDefault()
        {
            _output.CurrentValue = default(Toutput);
        }

        protected abstract void ReAggregate();
    }
}
