/*
 * CLINQ 
 * Continuous average Monitor Class
 * Created by: Kevin Hoffman
 * Created on: 04/16/2008
 */
using System;
using System.ComponentModel;
using System.Linq;

namespace ContinuousLinq.Aggregates
{
    internal class ContinuousAverageMonitorDecimal<T> : AggregateViewAdapter<T, decimal> where T:INotifyPropertyChanged
    {        
        public ContinuousAverageMonitorDecimal(InputCollectionWrapper<T> input,
            ContinuousValue<decimal> output,
            Func<T, decimal> averageFunc) : base(input, output, averageFunc)
        {            
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Average(this.AggFunc);
        }
    }

    internal class ContinuousAverageMonitorDouble<T> : AggregateViewAdapter<T, double> where T:INotifyPropertyChanged
    {
        public ContinuousAverageMonitorDouble(InputCollectionWrapper<T> input,
            ContinuousValue<double> output,
            Func<T, double> averageFunc) : base(input, output, averageFunc)
        {            
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Average(this.AggFunc);
        }
    }

    internal class ContinuousAverageMonitorFloat<T> : AggregateViewAdapter<T, float> where T : INotifyPropertyChanged
    {
        public ContinuousAverageMonitorFloat(InputCollectionWrapper<T> input,
            ContinuousValue<float> output,
            Func<T, float> averageFunc)
            : base(input, output, averageFunc)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Average(this.AggFunc);
        }
    }

    internal class ContinuousAverageMonitorDoubleInt<T> : AggregateViewAdapter<T, int, double> where T : INotifyPropertyChanged
    {
        public ContinuousAverageMonitorDoubleInt(InputCollectionWrapper<T> input,
            ContinuousValue<double> output,
            Func<T, int> averageFunc)
            : base(input, output, averageFunc)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Average(this.AggFunc);
        }
    }

    internal class ContinuousAverageMonitorDoubleLong<T> : AggregateViewAdapter<T, long, double> where T : INotifyPropertyChanged
    {
        public ContinuousAverageMonitorDoubleLong(InputCollectionWrapper<T> input,
            ContinuousValue<double> output,
            Func<T, long> averageFunc)
            : base(input, output, averageFunc)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Average(this.AggFunc);
        }
    }
}
