/*
 * CLINQ 
 * Continuous Minimum Monitor Class
 * Created by: Kevin Hoffman
 * Created on: 04/16/2008
 */
using System;
using System.ComponentModel;
using System.Linq;

namespace ContinuousLinq.Aggregates
{
    internal class ContinuousMinMonitorInt<T> : AggregateViewAdapter<T, int> where T : INotifyPropertyChanged
    {
        public ContinuousMinMonitorInt(InputCollectionWrapper<T> input,
                                       ContinuousValue<int> output,
                                       Func<T, int> minFunc)
            : base(input, output, minFunc)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Min(this.AggFunc);
        }
    }

    internal class ContinuousMinMonitorLong<T> : AggregateViewAdapter<T, long> where T : INotifyPropertyChanged
    {
        public ContinuousMinMonitorLong(InputCollectionWrapper<T> input,
                                        ContinuousValue<long> output,
                                        Func<T, long> minFunc)
            : base(input, output, minFunc)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Min(this.AggFunc);
        }
    }

    internal class ContinuousMinMonitorDouble<T> : AggregateViewAdapter<T, double> where T : INotifyPropertyChanged
    {
        public ContinuousMinMonitorDouble(InputCollectionWrapper<T> input,
                                          ContinuousValue<double> output,
                                          Func<T, double> minFunc)
            : base(input, output, minFunc)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Min(this.AggFunc);
        }
    }

    internal class ContinuousMinMonitorFloat<T> : AggregateViewAdapter<T, float> where T : INotifyPropertyChanged
    {
        public ContinuousMinMonitorFloat(InputCollectionWrapper<T> input,
                                         ContinuousValue<float> output,
                                         Func<T, float> minFunc)
            : base(input, output, minFunc)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Min(this.AggFunc);
        }
    }

    internal class ContinuousMinMonitorDecimal<T> : AggregateViewAdapter<T, decimal> where T : INotifyPropertyChanged
    {
        public ContinuousMinMonitorDecimal(InputCollectionWrapper<T> input,
                                           ContinuousValue<decimal> output,
                                           Func<T, decimal> minFunc)
            : base(input, output, minFunc)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Min(this.AggFunc);
        }
    }
}
