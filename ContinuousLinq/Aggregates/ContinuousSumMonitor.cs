using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ContinuousLinq.Aggregates
{
    public abstract class ContinuousSumMonitor<T>
    {
        protected ObservableCollection<T> _input;

        public ContinuousSumMonitor(ObservableCollection<T> input)
        {
            _input = input;
            _input.CollectionChanged += 
                new NotifyCollectionChangedEventHandler(input_CollectionChanged);
        }

        protected void input_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Resum();
        }

        protected virtual void Resum()
        {
        }
    }    

    public class ContinuousSumMonitorInt<T> : AggregateViewAdapter<T> where T : INotifyPropertyChanged
    {
        private ContinuousValue<int> _output;
        private Func<T, int> _sumFunc;

        public ContinuousSumMonitorInt(ObservableCollection<T> input,
            ContinuousValue<int> output,
            Func<T, int> sumFunc) : base(input)
        {
            _output = output;
            _sumFunc = sumFunc;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Sum<T>(_sumFunc);
        }        
    }

    public class ContinuousSumMonitorDouble<T> : AggregateViewAdapter<T> where T: INotifyPropertyChanged
    {
        private ContinuousValue<double> _output;
        private Func<T, double> _sumFunc;

        public ContinuousSumMonitorDouble(ObservableCollection<T> input, ContinuousValue<double> output, Func<T, double> sumFunc)
            : base(input)
        {
            _output = output;
            _sumFunc = sumFunc;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Sum<T>(_sumFunc);
        }
    }

    public class ContinuousSumMonitorDecimal<T> : AggregateViewAdapter<T> where T: INotifyPropertyChanged
    {
        private ContinuousValue<decimal> _output;
        private Func<T, decimal> _sumFunc;

        public ContinuousSumMonitorDecimal(ObservableCollection<T> input, ContinuousValue<decimal> output, Func<T, decimal> sumFunc) : base(input)
        {
            _output = output;
            _sumFunc = sumFunc;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Sum<T>(_sumFunc);
        }
    }

    public class ContinuousSumMonitorFloat<T> : AggregateViewAdapter<T> where T: INotifyPropertyChanged
    {
        private ContinuousValue<float> _output;
        private Func<T, float> _sumFunc;

        public ContinuousSumMonitorFloat(ObservableCollection<T> input, ContinuousValue<float> output, Func<T, float> sumFunc)
            : base(input)
        {
            _output = output;
            _sumFunc = sumFunc;
        }

        protected override void ReAggregate()
        {            
            _output.CurrentValue = _input.Sum<T>(_sumFunc);
        }
    }

    public class ContinuousSumMonitorLong<T> : AggregateViewAdapter<T> where T:INotifyPropertyChanged
    {
        private ContinuousValue<long> _output;
        private Func<T, long> _sumFunc;

        public ContinuousSumMonitorLong(ObservableCollection<T> input, ContinuousValue<long> output, Func<T, long> sumFunc) : base(input)
        {
            _output = output;
            _sumFunc = sumFunc;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Sum<T>(_sumFunc);
        }
    }
}
