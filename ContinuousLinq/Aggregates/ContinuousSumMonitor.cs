using System;
using System.ComponentModel;
using System.Linq;

namespace ContinuousLinq.Aggregates
{
    internal class ContinuousSumMonitorInt<T> : AggregateViewAdapter<T, int> where T : INotifyPropertyChanged
    {
        public ContinuousSumMonitorInt(InputCollectionWrapper<T> input,
                                       ContinuousValue<int> output,
                                       Func<T, int> sumFunc)
            : base(input, output, sumFunc)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Sum(this.AggFunc);
        }
    }

    internal class ContinuousSumMonitorDouble<T> : AggregateViewAdapter<T, double> where T : INotifyPropertyChanged
    {
        public ContinuousSumMonitorDouble(InputCollectionWrapper<T> input, ContinuousValue<double> output,
                                          Func<T, double> sumFunc)
            : base(input, output, sumFunc)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Sum(this.AggFunc);
        }
    }

    internal class ContinuousSumMonitorDecimal<T> : AggregateViewAdapter<T, decimal> where T : INotifyPropertyChanged
    {
        public ContinuousSumMonitorDecimal(InputCollectionWrapper<T> input, ContinuousValue<decimal> output,
                                           Func<T, decimal> sumFunc)
            : base(input, output, sumFunc)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Sum(this.AggFunc);
        }
    }

    internal class ContinuousSumMonitorFloat<T> : AggregateViewAdapter<T, float> where T : INotifyPropertyChanged
    {
        public ContinuousSumMonitorFloat(InputCollectionWrapper<T> input, ContinuousValue<float> output,
                                         Func<T, float> sumFunc)
            : base(input, output, sumFunc)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Sum(this.AggFunc);
        }
    }

    internal class ContinuousSumMonitorLong<T> : AggregateViewAdapter<T, long> where T : INotifyPropertyChanged
    {
        public ContinuousSumMonitorLong(InputCollectionWrapper<T> input, ContinuousValue<long> output,
                                        Func<T, long> sumFunc)
            : base(input, output, sumFunc)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = this.InputCollection.Sum(this.AggFunc);
        }
    }
}
