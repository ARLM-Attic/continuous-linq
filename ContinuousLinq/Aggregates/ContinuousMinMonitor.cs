/*
 * CLINQ 
 * Continuous Minimum Monitor Class
 * Created by: Kevin Hoffman
 * Created on: 04/16/2008
 */
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace ContinuousLinq.Aggregates
{
    internal abstract class ContinuousMinMonitor<Tinput, Toutput> : AggregateViewAdapter<Tinput> where Tinput : INotifyPropertyChanged
    {
        protected readonly ContinuousValue<Toutput> _output;
        protected readonly Func<Tinput, Toutput> _minFunc;

        protected ContinuousMinMonitor(ObservableCollection<Tinput> input,
                                       ContinuousValue<Toutput> output,
                                       Func<Tinput, Toutput> minFunc)
            : base(input)
        {
            _output = output;
            _output.SourceAdapter = this;
            _minFunc = minFunc;
            ReAggregate();
        }

        protected ContinuousMinMonitor(ReadOnlyObservableCollection<Tinput> input,
                                       ContinuousValue<Toutput> output,
                                       Func<Tinput, Toutput> minFunc)
            : base(input)
        {
            _output = output;
            _output.SourceAdapter = this;
            _minFunc = minFunc;
            ReAggregate();
        }
    }

    internal class ContinuousMinMonitorInt<T> : ContinuousMinMonitor<T, int> where T : INotifyPropertyChanged
    {
        public ContinuousMinMonitorInt(ObservableCollection<T> input,
                                       ContinuousValue<int> output,
                                       Func<T, int> minFunc)
            : base(input, output, minFunc)
        {
        }

        public ContinuousMinMonitorInt(ReadOnlyObservableCollection<T> input,
                                       ContinuousValue<int> output,
                                       Func<T, int> minFunc)
            : base(input, output, minFunc)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                _output.CurrentValue = this.Input.Min(_minFunc);
            }
            else
            {
                _output.CurrentValue = default(int);
            }
        }
    }

    internal class ContinuousMinMonitorLong<T> : ContinuousMinMonitor<T, long> where T : INotifyPropertyChanged
    {
        public ContinuousMinMonitorLong(ObservableCollection<T> input,
                                        ContinuousValue<long> output,
                                        Func<T, long> minFunc)
            : base(input, output, minFunc)
        {
        }

        public ContinuousMinMonitorLong(ReadOnlyObservableCollection<T> input,
                                        ContinuousValue<long> output,
                                        Func<T, long> minFunc)
            : base(input, output, minFunc)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                _output.CurrentValue = this.Input.Min(_minFunc);
            }
            else
            {
                _output.CurrentValue = default(long);
            }
        }
    }

    internal class ContinuousMinMonitorDouble<T> : ContinuousMinMonitor<T, double> where T : INotifyPropertyChanged
    {
        public ContinuousMinMonitorDouble(ObservableCollection<T> input,
                                          ContinuousValue<double> output,
                                          Func<T, double> minFunc)
            : base(input, output, minFunc)
        {
        }

        public ContinuousMinMonitorDouble(ReadOnlyObservableCollection<T> input,
                                          ContinuousValue<double> output,
                                          Func<T, double> minFunc)
            : base(input, output, minFunc)
        {
        }

        protected override void ReAggregate()
        {            
            if (this.Input.Count > 0)
            {
                _output.CurrentValue = this.Input.Min(_minFunc);
            }
            else
            {
                _output.CurrentValue = default(double);
            }
        }
    }

    internal class ContinuousMinMonitorFloat<T> : ContinuousMinMonitor<T, float> where T : INotifyPropertyChanged
    {
        public ContinuousMinMonitorFloat(ObservableCollection<T> input,
                                         ContinuousValue<float> output,
                                         Func<T, float> minFunc)
            : base(input, output, minFunc)
        {
        }

        public ContinuousMinMonitorFloat(ReadOnlyObservableCollection<T> input,
                                         ContinuousValue<float> output,
                                         Func<T, float> minFunc)
            : base(input, output, minFunc)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                _output.CurrentValue = this.Input.Min(_minFunc);
            }
            else
            {
                _output.CurrentValue = default(float);
            }
        }
    }

    internal class ContinuousMinMonitorDecimal<T> : ContinuousMinMonitor<T, decimal> where T : INotifyPropertyChanged
    {
        public ContinuousMinMonitorDecimal(ObservableCollection<T> input,
                                           ContinuousValue<decimal> output,
                                           Func<T, decimal> minFunc)
            : base(input, output, minFunc)
        {
        }

        public ContinuousMinMonitorDecimal(ReadOnlyObservableCollection<T> input,
                                           ContinuousValue<decimal> output,
                                           Func<T, decimal> minFunc)
            : base(input, output, minFunc)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                _output.CurrentValue = this.Input.Min(_minFunc);
            }
            else
            {
                _output.CurrentValue = default(decimal);
            }
        }
    }
}