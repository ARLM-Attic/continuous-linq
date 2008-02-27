using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ContinuousLinq
{
    /// <summary>
    /// Allows continuous queries to be created using a custom select clause
    /// while still maintaining the continous output result set.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    internal sealed class SelectingViewAdapter<TSource, TResult> : ViewAdapter<TSource, TResult> 
        where TSource : INotifyPropertyChanged
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
            foreach (TSource item in input.InnerAsList)
            {
                output.Add(func(item));
            }
        }

        protected override void OnCollectionItemPropertyChanged(TSource item, string propertyName)
        {
            // Damn, no index.
            IList<TSource> list = this.InputCollection;
            int index = list.IndexOf(item);
            this.OutputCollection[index] = _func(list[index]);
        }

        protected override void OnInputCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                int index = e.OldStartingIndex;
                this.OutputCollection[index] = _func((TSource)e.NewItems[0]);
            }
            else
            {
                base.OnInputCollectionChanged(e);
            }
        }

        protected override bool RemoveItem(TSource deleteItem, int index)
        {
            UnsubscribeFromItem(deleteItem);
            this.OutputCollection.RemoveAt(index);
            return true;
        }

        protected override void AddItem(TSource newItem, int index)
        {
            SubscribeToItem(newItem);
            this.OutputCollection.Insert(index, _func(newItem));
        }

        /*public override void ReEvaluate()
        {
            IList<TSource> innerAsList = _input.InnerAsList;
            for (int i = 0, n = innerAsList.Count; i < n; i++)
            {
                _output[i] = _func(innerAsList[i]);
            }
        }*/
    }
}
