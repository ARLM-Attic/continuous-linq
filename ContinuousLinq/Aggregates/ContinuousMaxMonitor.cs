/*
 * CLINQ 
 * Continuous Maximum Monitor Class
 * Created by: Kevin Hoffman
 * Created on: 04/16/2008
 */
using System;
using System.ComponentModel;
using System.Linq;

namespace ContinuousLinq.Aggregates
{
    internal class ContinuousMaxMonitorInt<T> : AggregateViewAdapter<T, int, int> where T : INotifyPropertyChanged
    {
        public ContinuousMaxMonitorInt(InputCollectionWrapper<T> input,
                                       ContinuousValue<int> output,
                                       Func<T, int> maxFunc)
            : base(input, output, maxFunc)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Max(this.AggFunc);
        }
    }

    internal class ContinuousMaxMonitorLong<T> : AggregateViewAdapter<T, long, long> where T : INotifyPropertyChanged
    {
        public ContinuousMaxMonitorLong(InputCollectionWrapper<T> input,
                                        ContinuousValue<long> output,
                                        Func<T, long> maxFunc)
            : base(input, output, maxFunc)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Max(this.AggFunc);
        }
    }

    internal class ContinuousMaxMonitorDouble<T> : AggregateViewAdapter<T, double> where T : INotifyPropertyChanged
    {
        public ContinuousMaxMonitorDouble(InputCollectionWrapper<T> input,
                                          ContinuousValue<double> output,
                                          Func<T, double> maxFunc)
            : base(input, output, maxFunc)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Max(this.AggFunc);
        }
    }

    internal class ContinuousMaxMonitorFloat<T> : AggregateViewAdapter<T, float> where T : INotifyPropertyChanged
    {
        public ContinuousMaxMonitorFloat(InputCollectionWrapper<T> input,
                                         ContinuousValue<float> output,
                                         Func<T, float> maxFunc)
            : base(input, output, maxFunc)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Max(this.AggFunc);
        }
    }

    internal class ContinuousMaxMonitorDecimal<T> : AggregateViewAdapter<T, decimal> where T : INotifyPropertyChanged
    {
        public ContinuousMaxMonitorDecimal(InputCollectionWrapper<T> input,
                                           ContinuousValue<decimal> output,
                                           Func<T, decimal> maxFunc)
            : base(input, output, maxFunc)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Max(this.AggFunc);
        }
    }
}
