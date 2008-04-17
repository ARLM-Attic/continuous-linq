using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace ContinuousLinq.Aggregates
{
    internal abstract class ContinuousSumMonitor<Tinput, Toutput> : AggregateViewAdapter<Tinput> where Tinput : INotifyPropertyChanged
    {
        protected readonly ContinuousValue<Toutput> _output;
        protected readonly Func<Tinput, Toutput> _sumFunc;

        protected ContinuousSumMonitor(ObservableCollection<Tinput> input,
                                       ContinuousValue<Toutput> output,
                                       Func<Tinput, Toutput> sumFunc)
            : base(input)
        {
            _output = output;
            _sumFunc = sumFunc;
            ReAggregate();
        }

        protected ContinuousSumMonitor(ReadOnlyObservableCollection<Tinput> input,
                                       ContinuousValue<Toutput> output,
                                       Func<Tinput, Toutput> sumFunc)
            : base(input)
        {
            _output = output;
            _sumFunc = sumFunc;
            ReAggregate();
        }

    }

    internal class ContinuousSumMonitorInt<T> : ContinuousSumMonitor<T, int> where T : INotifyPropertyChanged
    {
        public ContinuousSumMonitorInt(ObservableCollection<T> input,
                                       ContinuousValue<int> output,
                                       Func<T, int> sumFunc)
            : base(input, output, sumFunc)
        {
        }

        public ContinuousSumMonitorInt(ReadOnlyObservableCollection<T> input,
                                       ContinuousValue<int> output,
                                       Func<T, int> sumFunc)
            : base(input, output, sumFunc)
        {
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = this.Input.Sum(_sumFunc);
        }
    }

    internal class ContinuousSumMonitorDouble<T> : ContinuousSumMonitor<T, double> where T : INotifyPropertyChanged
    {
        public ContinuousSumMonitorDouble(ObservableCollection<T> input, ContinuousValue<double> output,
                                          Func<T, double> sumFunc)
            : base(input, output, sumFunc)
        {
        }

        public ContinuousSumMonitorDouble(ReadOnlyObservableCollection<T> input, ContinuousValue<double> output,
                                          Func<T, double> sumFunc)
            : base(input, output, sumFunc)
        {
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = this.Input.Sum(_sumFunc);
        }
    }

    internal class ContinuousSumMonitorDecimal<T> : ContinuousSumMonitor<T, decimal> where T : INotifyPropertyChanged
    {
        public ContinuousSumMonitorDecimal(ObservableCollection<T> input, ContinuousValue<decimal> output,
                                           Func<T, decimal> sumFunc)
            : base(input, output, sumFunc)
        {
        }

        public ContinuousSumMonitorDecimal(ReadOnlyObservableCollection<T> input, ContinuousValue<decimal> output,
                                           Func<T, decimal> sumFunc)
            : base(input, output, sumFunc)
        {
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = this.Input.Sum(_sumFunc);
        }
    }

    internal class ContinuousSumMonitorFloat<T> : ContinuousSumMonitor<T, float> where T : INotifyPropertyChanged
    {
        public ContinuousSumMonitorFloat(ObservableCollection<T> input, ContinuousValue<float> output,
                                         Func<T, float> sumFunc)
            : base(input, output, sumFunc)
        {
        }

        public ContinuousSumMonitorFloat(ReadOnlyObservableCollection<T> input, ContinuousValue<float> output,
                                         Func<T, float> sumFunc)
            : base(input, output, sumFunc)
        {
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = this.Input.Sum(_sumFunc);
        }
    }

    internal class ContinuousSumMonitorLong<T> : ContinuousSumMonitor<T, long> where T : INotifyPropertyChanged
    {
        public ContinuousSumMonitorLong(ObservableCollection<T> input, ContinuousValue<long> output,
                                        Func<T, long> sumFunc)
            : base(input, output, sumFunc)
        {
        }

        public ContinuousSumMonitorLong(ReadOnlyObservableCollection<T> input, ContinuousValue<long> output,
                                        Func<T, long> sumFunc)
            : base(input, output, sumFunc)
        {
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = this.Input.Sum(_sumFunc);
        }
    }
}