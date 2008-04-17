using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ContinuousLinq.Aggregates
{
    public class ContinuousCountMonitor<T> : AggregateViewAdapter<T> where T:INotifyPropertyChanged
    {
        private ContinuousValue<int> _output;

        public ContinuousCountMonitor(ObservableCollection<T> input, ContinuousValue<int> output) : base(input)
        {            
            _output = output;
        }

        protected override void ReAggregate()
        {
            _output.CurrentValue = _input.Count;
        }        
    }
}
