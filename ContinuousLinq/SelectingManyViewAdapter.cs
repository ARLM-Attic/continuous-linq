using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ContinuousLinq
{
    /// <summary>
    /// An adapter that allows LINQ queries to contain semi-complex 'select' clauses
    /// and still remain continuous.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    internal sealed class SelectingManyViewAdapter<TSource, TResult> :
        ViewAdapter<TSource, TResult> where TSource : INotifyPropertyChanged
    {
        private readonly Func<TSource, IEnumerable<TResult>> _func;
        private readonly List<int> _collectionLengths = new List<int>();

        public SelectingManyViewAdapter(InputCollectionWrapper<TSource> input,
            ContinuousCollection<TResult> output,
            Func<TSource, IEnumerable<TResult>> func)
            : base(input, output)
        {
            _func = func;

            if (func == null)
                throw new ArgumentNullException("func");
            foreach (TSource inItem in input.InnerAsList)
            {
                List<TResult> outList = new List<TResult>(func(inItem));
                output.AddRange(outList);
                _collectionLengths.Add(outList.Count);
            }
        }

        private int CountUntilIndex(int index)
        {
            int count = 0;
            for (int i = 0; i < index; i++)
            {
                count += _collectionLengths[i];
            }
            return count;
        }

        private void ReplacedOrChanged(TSource item, int inIndex)
        {
            int outIndex = CountUntilIndex(inIndex);
            int oldCount = _collectionLengths[inIndex];
            List<TResult> newList = new List<TResult>(_func(item));
            int newCount = newList.Count;
            _collectionLengths[inIndex] = newCount;
            if (newCount < oldCount)
            {
                int diff = oldCount - newCount;
                this.OutputCollection.RemoveRange(outIndex + newCount, diff);
            }
            else if (newCount > oldCount)
            {
                int diff = newCount - oldCount;
                this.OutputCollection.InsertRange(outIndex + oldCount, newList.GetRange(oldCount, diff));
                newList.RemoveRange(oldCount, diff);
            }

            this.OutputCollection.ReplaceRange(outIndex, newList);
        }

        protected override void OnCollectionItemPropertyChanged(TSource item, string propertyName)
        {
            int index = this.InputCollection.IndexOf(item);
            ReplacedOrChanged(item, index);
        }

        protected override void OnInputCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                int index = e.OldStartingIndex;
                ReplacedOrChanged((TSource)e.OldItems[0], index);
            }
            else
            {
                base.OnInputCollectionChanged(e);
            }
        }

        protected override bool RemoveItem(TSource deleteItem, int inIndex)
        {
            UnsubscribeFromItem(deleteItem);
            int outIndex = CountUntilIndex(inIndex);
            int count = _collectionLengths[inIndex];
            this.OutputCollection.RemoveRange(outIndex, count);
            _collectionLengths.RemoveAt(inIndex);
            return true;
        }

        protected override void AddItem(TSource newItem, int inIndex)
        {
            SubscribeToItem(newItem);
            int outIndex = CountUntilIndex(inIndex);
            List<TResult> outList = new List<TResult>(_func(newItem));
            this.OutputCollection.InsertRange(outIndex, outList);
            _collectionLengths.Insert(inIndex, outList.Count);
        }
    }
}
