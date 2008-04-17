using System;
using System.ComponentModel;

namespace ContinuousLinq.Aggregates
{
    internal class ContinuousStdDevMonitorInt<T> : AggregateViewAdapter<T, int, double> where T : INotifyPropertyChanged
    {
        public ContinuousStdDevMonitorInt(InputCollectionWrapper<T> input,
                                          ContinuousValue<double> output,
                                          Func<T, int> devValueSelector)
            : base(input, output, devValueSelector)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = StdDev.Compute(this.AggFunc, this.InputCollection);
        }
    }

    internal class ContinuousStdDevMonitorDouble<T> : AggregateViewAdapter<T, double, double> where T : INotifyPropertyChanged
    {
        public ContinuousStdDevMonitorDouble(InputCollectionWrapper<T> input,
                                             ContinuousValue<double> output,
                                             Func<T, double> devValueSelector)
            : base(input, output, devValueSelector)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = StdDev.Compute(this.AggFunc, this.InputCollection);
        }
    }

    internal class ContinuousStdDevMonitorFloat<T> : AggregateViewAdapter<T, float, double> where T : INotifyPropertyChanged
    {
        public ContinuousStdDevMonitorFloat(InputCollectionWrapper<T> input,
                                            ContinuousValue<double> output,
                                            Func<T, float> devValueSelector)
            : base(input, output, devValueSelector)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = StdDev.Compute(this.AggFunc, this.InputCollection);
        }
    }

    internal class ContinuousStdDevMonitorDecimal<T> : AggregateViewAdapter<T, decimal, double> where T : INotifyPropertyChanged
    {
        public ContinuousStdDevMonitorDecimal(InputCollectionWrapper<T> input,
                                              ContinuousValue<double> output,
                                              Func<T, decimal> devValueSelector)
            : base(input, output, devValueSelector)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = StdDev.Compute(this.AggFunc, this.InputCollection);
        }
    }

    internal class ContinuousStdDevMonitorLong<T> : AggregateViewAdapter<T, long, double> where T : INotifyPropertyChanged
    {
        public ContinuousStdDevMonitorLong(InputCollectionWrapper<T> input,
                                           ContinuousValue<double> output,
                                           Func<T, long> devValueSelector)
            : base(input, output, devValueSelector)
        {
        }

        protected override void ReAggregate()
        {
            this.Output.CurrentValue = StdDev.Compute(this.AggFunc, this.InputCollection);
        }
    }
}
