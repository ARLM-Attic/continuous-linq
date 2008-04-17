using System.ComponentModel;

namespace ContinuousLinq.Aggregates
{
    internal class ContinuousCountMonitor<T> : AggregateViewAdapter<T, int> where T : INotifyPropertyChanged
    {
        public ContinuousCountMonitor(InputCollectionWrapper<T> input, ContinuousValue<int> output)
            : base(input, output, null)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Count;
        }
    }
}
