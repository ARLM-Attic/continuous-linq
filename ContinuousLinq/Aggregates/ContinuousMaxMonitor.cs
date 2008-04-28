/*
 * CLINQ 
 * Continuous Maximum Monitor Class
 * Created by: Kevin Hoffman
 * Created on: 04/16/2008
 */
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace ContinuousLinq.Aggregates
{
    internal abstract class ContinuousMaxMonitor<Tinput, Toutput> : 
        AggregateViewAdapter<Tinput> where Tinput : INotifyPropertyChanged
    {
        protected readonly ContinuousValue<Toutput> _output;
        protected readonly Func<Tinput, Toutput> _maxFunc;

        protected ContinuousMaxMonitor(ObservableCollection<Tinput> input,
                                       ContinuousValue<Toutput> output,
                                       Func<Tinput, Toutput> maxFunc)
            : base(input)
        {
            _output = output;
            _output.SourceAdapter = this; // backreference required to avoid premature GC from weak references!
            _maxFunc = maxFunc;
            ReAggregate();
        }

        protected ContinuousMaxMonitor(ReadOnlyObservableCollection<Tinput> input,
                                       ContinuousValue<Toutput> output,
                                       Func<Tinput, Toutput> maxFunc)
            : base(input)
        {
            _output = output;
            _output.SourceAdapter = this;
            _maxFunc = maxFunc;
            ReAggregate();
        }
    }

    internal class ContinuousMaxMonitorInt<T> : ContinuousMaxMonitor<T, int> where T : INotifyPropertyChanged
    {
        public ContinuousMaxMonitorInt(ObservableCollection<T> input,
                                       ContinuousValue<int> output,
                                       Func<T, int> maxFunc)
            : base(input, output, maxFunc)
        {
        }

        public ContinuousMaxMonitorInt(ReadOnlyObservableCollection<T> input,
                                       ContinuousValue<int> output,
                                       Func<T, int> maxFunc)
            : base(input, output, maxFunc)
        {
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = this.Input.Max(_maxFunc);
        }
    }

    internal class ContinuousMaxMonitorLong<T> : ContinuousMaxMonitor<T, long> where T : INotifyPropertyChanged
    {
        public ContinuousMaxMonitorLong(ObservableCollection<T> input,
                                        ContinuousValue<long> output,
                                        Func<T, long> maxFunc)
            : base(input, output, maxFunc)
        {
        }

        public ContinuousMaxMonitorLong(ReadOnlyObservableCollection<T> input,
                                        ContinuousValue<long> output,
                                        Func<T, long> maxFunc)
            : base(input, output, maxFunc)
        {
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = this.Input.Max(_maxFunc);
        }
    }

    internal class ContinuousMaxMonitorDouble<T> : 
        ContinuousMaxMonitor<T, double> where T : INotifyPropertyChanged
    {
        public ContinuousMaxMonitorDouble(ObservableCollection<T> input,
                                          ContinuousValue<double> output,
                                          Func<T, double> maxFunc)
            : base(input, output, maxFunc)
        {
        }

        public ContinuousMaxMonitorDouble(ReadOnlyObservableCollection<T> input,
                                          ContinuousValue<double> output,
                                          Func<T, double> maxFunc)
            : base(input, output, maxFunc)
        {
        }

        protected override void ReAggregate()
        {
            if (this.Input.Count > 0)
            {
                _output.CurrentValue = this.Input.Max(_maxFunc);
            }
            else
            {
                _output.CurrentValue = default(double);
            }
        }
    }

    internal class ContinuousMaxMonitorFloat<T> : ContinuousMaxMonitor<T, float> where T : INotifyPropertyChanged
    {
        public ContinuousMaxMonitorFloat(ObservableCollection<T> input,
                                         ContinuousValue<float> output,
                                         Func<T, float> maxFunc)
            : base(input, output, maxFunc)
        {
        }

        public ContinuousMaxMonitorFloat(ReadOnlyObservableCollection<T> input,
                                         ContinuousValue<float> output,
                                         Func<T, float> maxFunc)
            : base(input, output, maxFunc)
        {
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = this.Input.Max(_maxFunc);
        }
    }

    internal class ContinuousMaxMonitorDecimal<T> : ContinuousMaxMonitor<T, decimal> where T : INotifyPropertyChanged
    {
        public ContinuousMaxMonitorDecimal(ObservableCollection<T> input,
                                           ContinuousValue<decimal> output,
                                           Func<T, decimal> maxFunc)
            : base(input, output, maxFunc)
        {
        }

        public ContinuousMaxMonitorDecimal(ReadOnlyObservableCollection<T> input,
                                           ContinuousValue<decimal> output,
                                           Func<T, decimal> maxFunc)
            : base(input, output, maxFunc)
        {
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = this.Input.Max(_maxFunc);
        }
    }
}