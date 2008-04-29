using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            ContinuousValue<double> output = new ContinuousValue<double>();
            ContinuousVwapMonitor<T> vwapMonitor =
                new ContinuousVwapMonitor<T>(input, priceSelector, quantitySelector, output);
            return output;
        }
    }

    public class ContinuousVwapMonitor<T> : AggregateViewAdapter<T> where T:INotifyPropertyChanged
    {
        private ContinuousValue<double> _output;
        private Func<T, double> _priceSelector;
        private Func<T, int> _qtySelector;

        public ContinuousVwapMonitor(ObservableCollection<T> input,
            Func<T, double> priceSelector,
            Func<T, int> quantitySelector,
            ContinuousValue<double> output)
            : base(input)
        {
            _output = output;
            SetSourceAdapter(_output, this);
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
            SetCurrentValue<double>(_output, vwap);
        }
    }
}
