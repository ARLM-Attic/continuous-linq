/*
 * CLINQ 
 * Continuous average Monitor Class
 * Created by: Kevin Hoffman
 * Created on: 04/16/2008
 */
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace ContinuousLinq.Aggregates
{
    internal abstract class ContinuousAverageMonitor<Tinput, Tfunc, Toutput> : AggregateViewAdapter<Tinput>
        where Tinput : INotifyPropertyChanged
    {
        protected readonly ContinuousValue<Toutput> _output;
        protected readonly Func<Tinput, Tfunc> _averageFunc;

        protected ContinuousAverageMonitor(ObservableCollection<Tinput> input,
                                           ContinuousValue<Toutput> output,
                                           Func<Tinput, Tfunc> averageFunc)
            : base(input)
        {
            _output = output;
            _averageFunc = averageFunc;
            ReAggregate();
        }

        protected ContinuousAverageMonitor(ReadOnlyObservableCollection<Tinput> input,
                                           ContinuousValue<Toutput> output,
                                           Func<Tinput, Tfunc> averageFunc)
            : base(input)
        {
            _output = output;
            _averageFunc = averageFunc;
            ReAggregate();
        }
    }

    internal class ContinuousAverageMonitorDecimal<T> : ContinuousAverageMonitor<T, decimal, decimal>
        where T : INotifyPropertyChanged
    {
        public ContinuousAverageMonitorDecimal(ObservableCollection<T> input,
                                               ContinuousValue<decimal> output,
                                               Func<T, decimal> averageFunc)
            : base(input, output, averageFunc)
        {
        }

        public ContinuousAverageMonitorDecimal(ReadOnlyObservableCollection<T> input,
                                               ContinuousValue<decimal> output,
                                               Func<T, decimal> averageFunc)
            : base(input, output, averageFunc)
        {
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = this.Input.Average(_averageFunc);
        }
    }

    internal class ContinuousAverageMonitorDouble<T> : ContinuousAverageMonitor<T, double, double >
        where T : INotifyPropertyChanged
    {
        public ContinuousAverageMonitorDouble(ObservableCollection<T> input,
                                              ContinuousValue<double> output,
                                              Func<T, double> averageFunc)
            : base(input, output, averageFunc)
        {
        }

        public ContinuousAverageMonitorDouble(ReadOnlyObservableCollection<T> input,
                                              ContinuousValue<double> output,
                                              Func<T, double> averageFunc)
            : base(input, output, averageFunc)
        {
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = this.Input.Average(_averageFunc);
        }
    }

    internal class ContinuousAverageMonitorFloat<T> : ContinuousAverageMonitor<T, float, float>
        where T : INotifyPropertyChanged
    {
        public ContinuousAverageMonitorFloat(ObservableCollection<T> input,
                                             ContinuousValue<float> output,
                                             Func<T, float> averageFunc)
            : base(input, output, averageFunc)
        {
        }

        public ContinuousAverageMonitorFloat(ReadOnlyObservableCollection<T> input,
                                             ContinuousValue<float> output,
                                             Func<T, float> averageFunc)
            : base(input, output, averageFunc)
        {
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = this.Input.Average(_averageFunc);
        }
    }

    internal class ContinuousAverageMonitorDoubleInt<T> : ContinuousAverageMonitor<T, int, double> where T : INotifyPropertyChanged
    {
        public ContinuousAverageMonitorDoubleInt(ObservableCollection<T> input,
                                                 ContinuousValue<double> output,
                                                 Func<T, int> averageFunc)
            : base(input, output, averageFunc)
        {
        }

        public ContinuousAverageMonitorDoubleInt(ReadOnlyObservableCollection<T> input,
                                                 ContinuousValue<double> output,
                                                 Func<T, int> averageFunc)
            : base(input, output, averageFunc)
        {
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = this.Input.Average(_averageFunc);
        }
    }

    internal class ContinuousAverageMonitorDoubleLong<T> : ContinuousAverageMonitor<T, long, double> where T : INotifyPropertyChanged
    {
        public ContinuousAverageMonitorDoubleLong(ObservableCollection<T> input,
                                                  ContinuousValue<double> output,
                                                  Func<T, long> averageFunc)
            : base(input, output, averageFunc)
        {
        }

        public ContinuousAverageMonitorDoubleLong(ReadOnlyObservableCollection<T> input,
                                                  ContinuousValue<double> output,
                                                  Func<T, long> averageFunc)
            : base(input, output, averageFunc)
        {
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = this.Input.Average(_averageFunc);
        }
    }
}