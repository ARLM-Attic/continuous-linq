using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ContinuousLinq.Aggregates
{
    internal abstract class ContinuousStdDevMonitor<Tinput, Tfunc> : AggregateViewAdapter<Tinput, double> where Tinput : INotifyPropertyChanged
    {
        protected readonly Func<Tinput, Tfunc> _selector;

        protected ContinuousStdDevMonitor(ObservableCollection<Tinput> input,
                                          Func<Tinput, Tfunc> devValueSelector)
            : base(input)
        {
            _selector = devValueSelector;
            ReAggregate();
        }

        protected ContinuousStdDevMonitor(ReadOnlyObservableCollection<Tinput> input,
                                          Func<Tinput, Tfunc> devValueSelector)
            : base(input)
        {
            _selector = devValueSelector;
            ReAggregate();
        }
    }

    internal class ContinuousStdDevMonitorInt<T> : ContinuousStdDevMonitor<T, int> where T : INotifyPropertyChanged
    {
        public ContinuousStdDevMonitorInt(ObservableCollection<T> input,
                                          Func<T, int> devValueSelector)
            : base(input, devValueSelector)
        {
        }

        public ContinuousStdDevMonitorInt(ReadOnlyObservableCollection<T> input,
                                          Func<T, int> devValueSelector)
            : base(input, devValueSelector)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                SetCurrentValue(StdDev.Compute(_selector, this.Input));
            }
            else
            {
                SetCurrentValueToDefault();
            }
        }
    }

    internal class ContinuousStdDevMonitorDouble<T> : ContinuousStdDevMonitor<T, double> where T : INotifyPropertyChanged
    {
        public ContinuousStdDevMonitorDouble(ObservableCollection<T> input,
                                             Func<T, double> devValueSelector)
            : base(input, devValueSelector)
        {
        }

        public ContinuousStdDevMonitorDouble(ReadOnlyObservableCollection<T> input,
                                             Func<T, double> devValueSelector)
            : base(input, devValueSelector)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                SetCurrentValue(StdDev.Compute(_selector, this.Input));
            }
            else
            {
                SetCurrentValueToDefault();
            }
        }
    }

    internal class ContinuousStdDevMonitorFloat<T> : ContinuousStdDevMonitor<T, float> where T : INotifyPropertyChanged
    {
        public ContinuousStdDevMonitorFloat(ObservableCollection<T> input,
                                            Func<T, float> devValueSelector)
            : base(input, devValueSelector)
        {
        }

        public ContinuousStdDevMonitorFloat(ReadOnlyObservableCollection<T> input,
                                            Func<T, float> devValueSelector)
            : base(input, devValueSelector)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                SetCurrentValue(StdDev.Compute(_selector, this.Input));
            }
            else
            {
                SetCurrentValueToDefault();
            }
        }
    }

    internal class ContinuousStdDevMonitorDecimal<T> : ContinuousStdDevMonitor<T, decimal> where T : INotifyPropertyChanged
    {
        public ContinuousStdDevMonitorDecimal(ObservableCollection<T> input,
                                              Func<T, decimal> devValueSelector)
            : base(input, devValueSelector)
        {
        }

        public ContinuousStdDevMonitorDecimal(ReadOnlyObservableCollection<T> input,
                                              Func<T, decimal> devValueSelector)
            : base(input, devValueSelector)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                SetCurrentValue(StdDev.Compute(_selector, this.Input));
            }
            else
            {
                SetCurrentValueToDefault();
            }
        }
    }

    internal class ContinuousStdDevMonitorLong<T> : ContinuousStdDevMonitor<T, long> where T : INotifyPropertyChanged
    {
        public ContinuousStdDevMonitorLong(ObservableCollection<T> input,
                                           Func<T, long> devValueSelector)
            : base(input, devValueSelector)
        {
        }

        public ContinuousStdDevMonitorLong(ReadOnlyObservableCollection<T> input,
                                           Func<T, long> devValueSelector)
            : base(input, devValueSelector)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                SetCurrentValue(StdDev.Compute(_selector, this.Input));
            }
            else
            {
                SetCurrentValueToDefault();
            }
        }
    }
}