using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace ContinuousLinq.Aggregates
{
    internal abstract class ContinuousSumMonitor<Tinput, Toutput> : AggregateViewAdapter<Tinput, Toutput> where Tinput : INotifyPropertyChanged
    {
        protected readonly Func<Tinput, Toutput> _sumFunc;

        protected ContinuousSumMonitor(ObservableCollection<Tinput> input,
                                       Func<Tinput, Toutput> sumFunc)
            : base(input)
        {
            _sumFunc = sumFunc;
            ReAggregate();
        }

        protected ContinuousSumMonitor(ReadOnlyObservableCollection<Tinput> input,
                                       Func<Tinput, Toutput> sumFunc)
            : base(input)
        {
            _sumFunc = sumFunc;
            ReAggregate();
        }

    }

    internal class ContinuousSumMonitorInt<T> : ContinuousSumMonitor<T, int> where T : INotifyPropertyChanged
    {
        public ContinuousSumMonitorInt(ObservableCollection<T> input,
                                       Func<T, int> sumFunc)
            : base(input, sumFunc)
        {
        }

        public ContinuousSumMonitorInt(ReadOnlyObservableCollection<T> input,
                                       Func<T, int> sumFunc)
            : base(input, sumFunc)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                SetCurrentValue(this.Input.Sum(_sumFunc));
            }
            else
            {
                SetCurrentValueToDefault();
            }
        }
    }

    internal class ContinuousSumMonitorDouble<T> : ContinuousSumMonitor<T, double> where T : INotifyPropertyChanged
    {
        public ContinuousSumMonitorDouble(ObservableCollection<T> input,
                                          Func<T, double> sumFunc)
            : base(input, sumFunc)
        {
        }

        public ContinuousSumMonitorDouble(ReadOnlyObservableCollection<T> input,
                                          Func<T, double> sumFunc)
            : base(input, sumFunc)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                SetCurrentValue(this.Input.Sum(_sumFunc));
            }
            else
            {
                SetCurrentValueToDefault();
            }
        }
    }

    internal class ContinuousSumMonitorDecimal<T> : ContinuousSumMonitor<T, decimal> where T : INotifyPropertyChanged
    {
        public ContinuousSumMonitorDecimal(ObservableCollection<T> input,
                                           Func<T, decimal> sumFunc)
            : base(input, sumFunc)
        {
        }

        public ContinuousSumMonitorDecimal(ReadOnlyObservableCollection<T> input,
                                           Func<T, decimal> sumFunc)
            : base(input, sumFunc)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                SetCurrentValue(this.Input.Sum(_sumFunc));
            }
            else
            {
                SetCurrentValueToDefault();
            }
        }
    }

    internal class ContinuousSumMonitorFloat<T> : ContinuousSumMonitor<T, float> where T : INotifyPropertyChanged
    {
        public ContinuousSumMonitorFloat(ObservableCollection<T> input,
                                         Func<T, float> sumFunc)
            : base(input, sumFunc)
        {
        }

        public ContinuousSumMonitorFloat(ReadOnlyObservableCollection<T> input,
                                         Func<T, float> sumFunc)
            : base(input, sumFunc)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                SetCurrentValue(this.Input.Sum(_sumFunc));
            }
            else
            {
                SetCurrentValueToDefault();
            }
        }
    }

    internal class ContinuousSumMonitorLong<T> : ContinuousSumMonitor<T, long> where T : INotifyPropertyChanged
    {
        public ContinuousSumMonitorLong(ObservableCollection<T> input,
                                        Func<T, long> sumFunc)
            : base(input, sumFunc)
        {
        }

        public ContinuousSumMonitorLong(ReadOnlyObservableCollection<T> input,
                                        Func<T, long> sumFunc)
            : base(input, sumFunc)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                SetCurrentValue(this.Input.Sum(_sumFunc));
            }
            else
            {
                SetCurrentValueToDefault();
            }
        }
    }
}