using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ContinuousLinq.Aggregates
{
    internal class ContinuousCountMonitor<T> : AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        private readonly ContinuousValue<int> _output;

        public ContinuousCountMonitor(ObservableCollection<T> input, ContinuousValue<int> output)
            : base(input)
        {
            _output = output;
            ReAggregate();
        }

        public ContinuousCountMonitor(ReadOnlyObservableCollection<T> input, ContinuousValue<int> output)
            : base(input)
        {
            _output = output;
            ReAggregate();
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = this.Input.Count;
        }
    }
}