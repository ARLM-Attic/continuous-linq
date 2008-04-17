using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.Specialized;

namespace ContinuousLinq.Aggregates
{
    internal abstract class AggregateViewAdapter<INPUT, OUTPUT> : AggregateViewAdapter<INPUT, OUTPUT, OUTPUT>
        where INPUT : INotifyPropertyChanged
    {
        protected AggregateViewAdapter(InputCollectionWrapper<INPUT> input, ContinuousValue<OUTPUT> output,
                                       Func<INPUT, OUTPUT> aggFunc) : base(input, output, aggFunc)
        {
        }
    }

    internal abstract class AggregateViewAdapter<INPUT, FUNCOUT, OUTPUT> where INPUT : INotifyPropertyChanged
    {
        private readonly InputCollectionWrapper<INPUT> _input;
        private readonly ContinuousValue<OUTPUT> _output;
        private readonly Func<INPUT, FUNCOUT> _aggFunc;
        private readonly NotifyCollectionChangedEventHandler _collectionChangedDelegate;
        private readonly PropertyChangedEventHandler _propertyChangedDelegate;
        private readonly Dictionary<INPUT, WeakPropertyChangedHandler> _handlerMap =
            new Dictionary<INPUT, WeakPropertyChangedHandler>();

        protected AggregateViewAdapter(InputCollectionWrapper<INPUT> input, ContinuousValue<OUTPUT> output, Func<INPUT,FUNCOUT> aggFunc)
        {
            _input = input;
            _output = output;
            _aggFunc = aggFunc;

            _collectionChangedDelegate = ((sender, args) => OnInputCollectionChanged(args));
            _propertyChangedDelegate = ((sender, e) => ReAggregate());

            new WeakCollectionChangedHandler(input.InnerAsNotifier, _collectionChangedDelegate);

            foreach (INPUT item in this.InputCollection)
            {
                SubscribeToItem(item);
            }
            ReAggregate(); 
        }

        protected void SubscribeToItem(INPUT item)
        {
            if (_handlerMap.ContainsKey(item) == false)
            {
                _handlerMap[item] = new WeakPropertyChangedHandler(item, _propertyChangedDelegate);
            }
        }

        protected void UnsubscribeFromItem(INPUT item)
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
        protected IList<INPUT> InputCollection
        {
            get { return _input.InnerAsList; }
        }

        protected ContinuousValue<OUTPUT> Output
        {
            get { return _output; }
        }

        protected Func<INPUT, FUNCOUT> AggFunc
        {
            get { return _aggFunc; }
        }

        void OnInputCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                    UnsubscribeFromItem((INPUT) e.OldItems[0]);
                    break;
                case NotifyCollectionChangedAction.Add:
                    SubscribeToItem((INPUT) e.NewItems[0]);
                    break;
                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Move:
                    UnsubscribeFromItem((INPUT) e.OldItems[0]);
                    SubscribeToItem((INPUT) e.NewItems[0]);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    foreach (INPUT item in _input.InnerAsList)
                    {
                        UnsubscribeFromItem(item);
                    }
                    break;
            }
            ReAggregate();
        }

        protected abstract void ReAggregate();
    }
}
