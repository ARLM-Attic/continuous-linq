/*
 * CLINQ 
 * Continuous Minimum Monitor Class
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
    public class ContinuousMinMonitorInt<T> : AggregateViewAdapter<T> where T:INotifyPropertyChanged
    {
        private ContinuousValue<int> _output;
        private Func<T, int> _minFunc;

        public ContinuousMinMonitorInt(ObservableCollection<T> input,
            ContinuousValue<int> output,
            Func<T, int> minFunc)
            : base(input)
        {
            _output = output;
            _minFunc = minFunc;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Min(_minFunc);
        }
    }

    public class ContinuousMinMonitorLong<T> : AggregateViewAdapter<T> where T:INotifyPropertyChanged
    {
        private ContinuousValue<long> _output;
        private Func<T, long> _minFunc;

        public ContinuousMinMonitorLong(ObservableCollection<T> input,
            ContinuousValue<long> output,
            Func<T, long> minFunc)
            : base(input)
        {
            _output = output;
            _minFunc = minFunc;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Min(_minFunc);
        }
    }

    public class ContinuousMinMonitorDouble<T> : AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        private ContinuousValue<double> _output;
        private Func<T, double> _minFunc;
        public ContinuousMinMonitorDouble(ObservableCollection<T> input,
            ContinuousValue<double> output,
            Func<T, double> minFunc) : base(input)
        {
            _output = output;
            _minFunc = minFunc;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Min(_minFunc);
        }
    }

    public class ContinuousMinMonitorFloat<T> : AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        private ContinuousValue<float> _output;
        private Func<T, float> _minFunc;

        public ContinuousMinMonitorFloat(ObservableCollection<T> input,
            ContinuousValue<float> output,
            Func<T, float> minFunc) 
            : base(input)
        {
            _output = output;
            _minFunc = minFunc;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Min(_minFunc);
        }
    }

    public class ContinuousMinMonitorDecimal<T> : AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        private ContinuousValue<decimal> _output;
        private Func<T, decimal> _minFunc;

        public ContinuousMinMonitorDecimal(ObservableCollection<T> input,
            ContinuousValue<decimal> output,
            Func<T, decimal> minFunc) : base(input)
        {
            _output = output;
            _minFunc = minFunc;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Min(_minFunc);
        }
    }
    
}
