using System;
using ContinuousLinq.Aggregates;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace StockMonitorDemo.Extensions
{
    public static class VwapExtender
    {
        public static ContinuousValue<double> ContinuousVwap<T>(
            this ObservableCollection<T> input,
            Func<T, double> priceSelector,
            Func<T, int> quantitySelector) where T: INotifyPropertyChanged
        {
            return new ContinuousVwapMonitor<T>(input, priceSelector, quantitySelector).Value;
        }
    }

    internal class ContinuousVwapMonitor<T> : AggregateViewAdapter<T, double> where T:INotifyPropertyChanged
    {
        private readonly Func<T, double> _priceSelector;
        private readonly Func<T, int> _qtySelector;

        public ContinuousVwapMonitor(ObservableCollection<T> input,
            Func<T, double> priceSelector,
            Func<T, int> quantitySelector)
            : base(input)
        {
            _priceSelector = priceSelector;
            _qtySelector = quantitySelector;
            ReAggregate();
        }

        protected override void ReAggregate()
        {            
            int count = Input.Count;
            double weightedPrice = 0.0;
            int totalQuantity = 0;

            for (int x = 0; x < count; x++)
            {
                weightedPrice += _priceSelector(Input[x]) *
                    _qtySelector(Input[x]);
                totalQuantity += _qtySelector(Input[x]);
            }

            double vwap = weightedPrice / totalQuantity;
            SetCurrentValue(vwap);
        }
    }
}
