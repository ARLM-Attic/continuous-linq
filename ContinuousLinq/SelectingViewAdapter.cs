using System;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ContinuousLinq
{
    internal sealed class SelectingViewAdapter<TSource, TResult> :
        ViewAdapter<TSource, TResult> where TSource : IEquatable<TSource>, INotifyPropertyChanged
    {
        private readonly Func<TSource, TResult> _func;

        public SelectingViewAdapter(InputCollectionWrapper<TSource> input,
            ContinuousCollection<TResult> output,
            Func<TSource, TResult> func)
            : base(input, output)
        {
            _func = func;

            if (func == null)
                throw new ArgumentNullException("func");
            foreach (TSource item in _input.InnerAsList)
            {
                _output.Add(func(item));
            }
        }

        protected override void OnCollectionItemPropertyChanged(TSource item, string propertyName)
        {
            // Damn, no index.
            int index = _input.InnerAsList.IndexOf(item);
            _output[index] = _func(_input.InnerAsList[index]);
        }

        protected override void OnInputCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                int index = e.OldStartingIndex;
                _output[index] = _func(_input.InnerAsList[index]);
            }
            else
            {
                base.OnInputCollectionChanged(e);
            }
        }

        protected override bool RemoveItem(TSource deleteItem, int index)
        {
            UnsubscribeFromItem(deleteItem);
            _output.RemoveAt(index);
            return true;
        }

        protected override void AddItem(TSource newItem, int index)
        {
            SubscribeToItem(newItem);
            _output.Insert(index, _func(newItem));
        }
    }
}
