/*
 * CLINQ 
 * Continuous average Monitor Class
 * Created by: Kevin Hoffman
 * Created on: 04/16/2008
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ContinuousLinq.Aggregates
{
    public class ContinuousAverageMonitorDecimal<T> : AggregateViewAdapter<T> where T:INotifyPropertyChanged
    {        
        protected ContinuousValue<decimal> _output;
        protected Func<T, decimal> _averageFunc;

        public ContinuousAverageMonitorDecimal(ObservableCollection<T> input,
            ContinuousValue<decimal> output,
            Func<T, decimal> averageFunc) : base(input)
        {            
            _output = output;
            _averageFunc = averageFunc;         
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Average(_averageFunc);
        }
    }

    public class ContinuousAverageMonitorDouble<T> : AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        protected ContinuousValue<double> _output;
        protected Func<T, double> _averageFunc;

        public ContinuousAverageMonitorDouble(ObservableCollection<T> input,
            ContinuousValue<double> output,
            Func<T, double> averageFunc)
            : base(input)
        {
            _output = output;
            _averageFunc = averageFunc;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Average(_averageFunc);
        }
    }

    public class ContinuousAverageMonitorFloat<T> : AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        protected ContinuousValue<float> _output;
        protected Func<T, float> _averageFunc;

        public ContinuousAverageMonitorFloat(ObservableCollection<T> input,
            ContinuousValue<float> output,
            Func<T, float> averageFunc)
            : base(input)
        {
            _output = output;
            _averageFunc = averageFunc;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Average(_averageFunc);
        }
    }

    public class ContinuousAverageMonitorDoubleInt<T> : AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        protected ContinuousValue<double> _output;
        protected Func<T, int> _averageFunc;

        public ContinuousAverageMonitorDoubleInt(ObservableCollection<T> input,
            ContinuousValue<double> output,
            Func<T, int> averageFunc)
            : base(input)
        {
            _output = output;
            _averageFunc = averageFunc;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Average(_averageFunc);
        }
    }

    public class ContinuousAverageMonitorDoubleLong<T> : AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        protected ContinuousValue<double> _output;
        protected Func<T, long> _averageFunc;

        public ContinuousAverageMonitorDoubleLong(ObservableCollection<T> input,
            ContinuousValue<double> output,
            Func<T, long> averageFunc)
            : base(input)
        {
            _output = output;
            _averageFunc = averageFunc;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Average(_averageFunc);
        }
    }

}