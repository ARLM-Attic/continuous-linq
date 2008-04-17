/*
 * CLINQ 
 * Continuous Maximum Monitor Class
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
    public class ContinuousMaxMonitorInt<T> : AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        private ContinuousValue<int> _output;
        private Func<T, int> _maxFunc;

        public ContinuousMaxMonitorInt(ObservableCollection<T> input,
            ContinuousValue<int> output,
            Func<T, int> maxFunc)
            : base(input)
        {
            _output = output;
            _maxFunc = maxFunc;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Max(_maxFunc);
        }
    }

    public class ContinuousMaxMonitorLong<T> : AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        private ContinuousValue<long> _output;
        private Func<T, long> _maxFunc;

        public ContinuousMaxMonitorLong(ObservableCollection<T> input,
            ContinuousValue<long> output,
            Func<T, long> maxFunc)
            : base(input)
        {
            _output = output;
            _maxFunc = maxFunc;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Max(_maxFunc);
        }
    }

    public class ContinuousMaxMonitorDouble<T> : AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        private ContinuousValue<double> _output;
        private Func<T, double> _maxFunc;
        public ContinuousMaxMonitorDouble(ObservableCollection<T> input,
            ContinuousValue<double> output,
            Func<T, double> maxFunc)
            : base(input)
        {
            _output = output;
            _maxFunc = maxFunc;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Max(_maxFunc);
        }
    }

    public class ContinuousMaxMonitorFloat<T> : AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        private ContinuousValue<float> _output;
        private Func<T, float> _maxFunc;

        public ContinuousMaxMonitorFloat(ObservableCollection<T> input,
            ContinuousValue<float> output,
            Func<T, float> maxFunc)
            : base(input)
        {
            _output = output;
            _maxFunc = maxFunc;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Max(_maxFunc);
        }
    }

    public class ContinuousMaxMonitorDecimal<T> : AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        private ContinuousValue<decimal> _output;
        private Func<T, decimal> _maxFunc;

        public ContinuousMaxMonitorDecimal(ObservableCollection<T> input,
            ContinuousValue<decimal> output,
            Func<T, decimal> maxFunc)
            : base(input)
        {
            _output = output;
            _maxFunc = maxFunc;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Max(_maxFunc);
        }
    }

}
