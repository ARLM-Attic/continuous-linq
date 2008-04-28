using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ContinuousLinq.Aggregates
{
    internal abstract class ContinuousStdDevMonitor<Tinput, Tfunc> : AggregateViewAdapter<Tinput> where Tinput : INotifyPropertyChanged
    {
        protected readonly Func<Tinput, Tfunc> _selector;
        protected readonly ContinuousValue<double> _output;

        protected ContinuousStdDevMonitor(ObservableCollection<Tinput> input,
                                          ContinuousValue<double> output,
                                          Func<Tinput, Tfunc> devValueSelector)
            : base(input)
        {
            _output = output;
            _output.SourceAdapter = this;
            _selector = devValueSelector;
            ReAggregate();
        }

        protected ContinuousStdDevMonitor(ReadOnlyObservableCollection<Tinput> input,
                                          ContinuousValue<double> output,
                                          Func<Tinput, Tfunc> devValueSelector)
            : base(input)
        {
            _output = output;
            _output.SourceAdapter = this;
            _selector = devValueSelector;
            ReAggregate();
        }
    }

    internal class ContinuousStdDevMonitorInt<T> : ContinuousStdDevMonitor<T, int> where T : INotifyPropertyChanged
    {
        public ContinuousStdDevMonitorInt(ObservableCollection<T> input,
                                          ContinuousValue<double> output,
                                          Func<T, int> devValueSelector)
            : base(input, output, devValueSelector)
        {
        }

        public ContinuousStdDevMonitorInt(ReadOnlyObservableCollection<T> input,
                                          ContinuousValue<double> output,
                                          Func<T, int> devValueSelector)
            : base(input, output, devValueSelector)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                _output.CurrentValue = StdDev.Compute(_selector, this.Input);
            }
            else
            {
                _output.CurrentValue = default(double);
            }
        }
    }

    internal class ContinuousStdDevMonitorDouble<T> : ContinuousStdDevMonitor<T, double> where T : INotifyPropertyChanged
    {
        public ContinuousStdDevMonitorDouble(ObservableCollection<T> input,
                                             ContinuousValue<double> output,
                                             Func<T, double> devValueSelector)
            : base(input, output, devValueSelector)
        {
        }

        public ContinuousStdDevMonitorDouble(ReadOnlyObservableCollection<T> input,
                                             ContinuousValue<double> output,
                                             Func<T, double> devValueSelector)
            : base(input, output, devValueSelector)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                _output.CurrentValue = StdDev.Compute(_selector, this.Input);
            }
            else
            {
                _output.CurrentValue = default(double);
            }
        }
    }

    internal class ContinuousStdDevMonitorFloat<T> : ContinuousStdDevMonitor<T, float> where T : INotifyPropertyChanged
    {
        public ContinuousStdDevMonitorFloat(ObservableCollection<T> input,
                                            ContinuousValue<double> output,
                                            Func<T, float> devValueSelector)
            : base(input, output, devValueSelector)
        {
        }

        public ContinuousStdDevMonitorFloat(ReadOnlyObservableCollection<T> input,
                                            ContinuousValue<double> output,
                                            Func<T, float> devValueSelector)
            : base(input, output, devValueSelector)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                _output.CurrentValue = StdDev.Compute(_selector, this.Input);
            }
            else
            {
                _output.CurrentValue = default(double);
            }
        }
    }

    internal class ContinuousStdDevMonitorDecimal<T> : ContinuousStdDevMonitor<T, decimal> where T : INotifyPropertyChanged
    {
        public ContinuousStdDevMonitorDecimal(ObservableCollection<T> input,
                                              ContinuousValue<double> output,
                                              Func<T, decimal> devValueSelector)
            : base(input, output, devValueSelector)
        {
        }

        public ContinuousStdDevMonitorDecimal(ReadOnlyObservableCollection<T> input,
                                              ContinuousValue<double> output,
                                              Func<T, decimal> devValueSelector)
            : base(input, output, devValueSelector)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                _output.CurrentValue = StdDev.Compute(_selector, this.Input);
            }
            else
            {
                _output.CurrentValue = default(double);
            }
        }
    }

    internal class ContinuousStdDevMonitorLong<T> : ContinuousStdDevMonitor<T, long> where T : INotifyPropertyChanged
    {
        public ContinuousStdDevMonitorLong(ObservableCollection<T> input,
                                           ContinuousValue<double> output,
                                           Func<T, long> devValueSelector)
            : base(input, output, devValueSelector)
        {
        }

        public ContinuousStdDevMonitorLong(ReadOnlyObservableCollection<T> input,
                                           ContinuousValue<double> output,
                                           Func<T, long> devValueSelector)
            : base(input, output, devValueSelector)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0) 
            {
                _output.CurrentValue = StdDev.Compute(_selector, this.Input);
            }
            else
            {
                _output.CurrentValue = default(double);
            }
        }
    }
}