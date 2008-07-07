using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace ContinuousLinq
{
    internal sealed class ExceptViewAdapter<TSource> : ViewAdapter<TSource, TSource>
       where TSource : INotifyPropertyChanged
    {
        private IEqualityComparer<TSource> _comparer = null;

        public ExceptViewAdapter(InputCollectionWrapper<TSource> source, LinqContinuousCollection<TSource> output)
            : base(source, output)
        {
            ReEvaluate();
        }

        public ExceptViewAdapter(InputCollectionWrapper<TSource> source, LinqContinuousCollection<TSource> output,
            IEqualityComparer<TSource> comparer)
            : base(source, output)
        {
            _comparer = comparer;
            ReEvaluate();
        }

        protected override void AddItem(TSource newItem, int index)
        {            
            ReEvaluate();
        }

        protected override void Clear()
        {
            this.OutputCollection.Clear();
        }

        protected override void OnCollectionItemPropertyChanged(TSource item, string propertyName)
        {
            ReEvaluate();
        }

        protected override void OnInputCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnInputCollectionChanged(e);
            ReEvaluate();
        }

        protected override bool RemoveItem(TSource newItem, int index)
        {
            return this.OutputCollection.Remove(newItem);
        }

        public override void ReEvaluate()
        {
            // TODO            
        }
    }
}
