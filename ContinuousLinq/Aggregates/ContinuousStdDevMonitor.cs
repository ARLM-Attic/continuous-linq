using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ContinuousLinq.Aggregates
{                
    public class ContinuousStdDevMonitorInt<T> : AggregateViewAdapter<T> where T: INotifyPropertyChanged
    {
        protected Func<T, int> _selector;
        protected ContinuousValue<double> _output;

        public ContinuousStdDevMonitorInt(ObservableCollection<T> input,
            ContinuousValue<double> output,
            Func<T, int> devValueSelector) : base(input)
        {
            _output = output;
            _selector = devValueSelector;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = StdDev.Compute(_selector, _input);
        }       
    }

    public class ContinuousStdDevMonitorDouble<T> : AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        protected Func<T, double> _selector;
        protected ContinuousValue<double> _output;

        public ContinuousStdDevMonitorDouble(ObservableCollection<T> input,
            ContinuousValue<double> output,
            Func<T, double> devValueSelector) : base(input)
        {
            _output = output;
            _selector = devValueSelector;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = StdDev.Compute(_selector, _input);
        }       
    }

    public class ContinuousStdDevMonitorFloat<T> : AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        protected Func<T, float> _selector;
        protected ContinuousValue<double> _output;

        public ContinuousStdDevMonitorFloat(ObservableCollection<T> input,
            ContinuousValue<double> output,
            Func<T, float> devValueSelector)
            : base(input)
        {
            _output = output;
            _selector = devValueSelector;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = StdDev.Compute(_selector, _input);
        }
    }

    public class ContinuousStdDevMonitorDecimal<T> : AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        protected Func<T, decimal> _selector;
        protected ContinuousValue<double> _output;

        public ContinuousStdDevMonitorDecimal(ObservableCollection<T> input,
            ContinuousValue<double> output,
            Func<T, decimal> devValueSelector)
            : base(input)
        {
            _output = output;
            _selector = devValueSelector;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = StdDev.Compute(_selector, _input);
        }
    }

    public class ContinuousStdDevMonitorLong<T> : AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        protected Func<T, long> _selector;
        protected ContinuousValue<double> _output;

        public ContinuousStdDevMonitorLong(ObservableCollection<T> input,
            ContinuousValue<double> output,
            Func<T, long> devValueSelector)
            : base(input)
        {
            _output = output;
            _selector = devValueSelector;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = StdDev.Compute(_selector, _input);
        }
    }
}
