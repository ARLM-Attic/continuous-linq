/*
 * Continuous Aggregation Extensions
 * Created by: Kevin Hoffman
 * Created on: April 16, 2008
 */
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ContinuousLinq.Aggregates
{
    public static class ContinuousAggregationExtension
    {
        #region SUM

        public static ContinuousValue<int> ContinuousSum<T>(
            this ObservableCollection<T> input,
            Func<T, int> sumFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<int> output = new ContinuousValue<int>();
            new ContinuousSumMonitorInt<T>(input, output, sumFunc);
            return output;
        }

        public static ContinuousValue<int> ContinuousSum<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, int> sumFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<int> output = new ContinuousValue<int>();
            new ContinuousSumMonitorInt<T>(input, output, sumFunc);
            return output;
        }

        public static ContinuousValue<double> ContinuousSum<T>(
            this ObservableCollection<T> input,
            Func<T, double> sumFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousSumMonitorDouble<T>(input, output, sumFunc);
            return output;
        }

        public static ContinuousValue<double> ContinuousSum<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, double> sumFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousSumMonitorDouble<T>(input, output, sumFunc);
            return output;
        }

        public static ContinuousValue<decimal> ContinuousSum<T>(
            this ObservableCollection<T> input,
            Func<T, decimal> sumFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<decimal> output = new ContinuousValue<decimal>();
            new ContinuousSumMonitorDecimal<T>(input, output, sumFunc);
            return output;
        }

        public static ContinuousValue<decimal> ContinuousSum<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, decimal> sumFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<decimal> output = new ContinuousValue<decimal>();
            new ContinuousSumMonitorDecimal<T>(input, output, sumFunc);
            return output;
        }

        public static ContinuousValue<float> ContinuousSum<T>(
            this ObservableCollection<T> input,
            Func<T, float> sumFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<float> output = new ContinuousValue<float>();
            new ContinuousSumMonitorFloat<T>(input, output, sumFunc);
            return output;
        }

        public static ContinuousValue<float> ContinuousSum<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, float> sumFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<float> output = new ContinuousValue<float>();
            new ContinuousSumMonitorFloat<T>(input, output, sumFunc);
            return output;
        }

        public static ContinuousValue<long> ContinuousSum<T>(
            this ObservableCollection<T> input,
            Func<T, long> sumFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<long> output = new ContinuousValue<long>();
            new ContinuousSumMonitorLong<T>(input, output, sumFunc);
            return output;
        }

        public static ContinuousValue<long> ContinuousSum<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, long> sumFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<long> output = new ContinuousValue<long>();
            new ContinuousSumMonitorLong<T>(input, output, sumFunc);
            return output;
        }

        #endregion
        
        #region COUNT

        public static ContinuousValue<int> ContinuousCount<T>(
            this ObservableCollection<T> input) where T : INotifyPropertyChanged
        {
            ContinuousValue<int> output = new ContinuousValue<int>();
            new ContinuousCountMonitor<T>(input, output);
            return output;
        }

        public static ContinuousValue<int> ContinuousCount<T>(
            this ReadOnlyObservableCollection<T> input) where T : INotifyPropertyChanged
        {
            ContinuousValue<int> output = new ContinuousValue<int>();
            new ContinuousCountMonitor<T>(input, output);
            return output;
        }

        #endregion

        #region MIN

        public static ContinuousValue<int> ContinuousMin<T>(
            this ObservableCollection<T> input,
            Func<T, int> minFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<int> output = new ContinuousValue<int>();
            new ContinuousMinMonitorInt<T>(input, output, minFunc);
            return output;
        }

        public static ContinuousValue<int> ContinuousMin<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, int> minFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<int> output = new ContinuousValue<int>();
            new ContinuousMinMonitorInt<T>(input, output, minFunc);
            return output;
        }

        public static ContinuousValue<double> ContinuousMin<T>(
            this ObservableCollection<T> input,
            Func<T, double> minFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousMinMonitorDouble<T>(input, output, minFunc);
            return output;
        }

        public static ContinuousValue<double> ContinuousMin<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, double> minFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousMinMonitorDouble<T>(input, output, minFunc);
            return output;
        }

        public static ContinuousValue<decimal> ContinuousMin<T>(
            this ObservableCollection<T> input,
            Func<T, decimal> minFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<decimal> output = new ContinuousValue<decimal>();
            new ContinuousMinMonitorDecimal<T>(input, output, minFunc);
            return output;
        }

        public static ContinuousValue<decimal> ContinuousMin<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, decimal> minFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<decimal> output = new ContinuousValue<decimal>();
            new ContinuousMinMonitorDecimal<T>(input, output, minFunc);
            return output;
        }

        public static ContinuousValue<float> ContinuousMin<T>(
            this ObservableCollection<T> input,
            Func<T, float> minFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<float> output = new ContinuousValue<float>();
            new ContinuousMinMonitorFloat<T>(input, output, minFunc);
            return output;
        }

        public static ContinuousValue<float> ContinuousMin<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, float> minFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<float> output = new ContinuousValue<float>();
            new ContinuousMinMonitorFloat<T>(input, output, minFunc);
            return output;
        }

        public static ContinuousValue<long> ContinuousMin<T>(
            this ObservableCollection<T> input,
            Func<T, long> minFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<long> output = new ContinuousValue<long>();
            new ContinuousMinMonitorLong<T>(input, output, minFunc);
            return output;
        }

        public static ContinuousValue<long> ContinuousMin<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, long> minFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<long> output = new ContinuousValue<long>();
            new ContinuousMinMonitorLong<T>(input, output, minFunc);
            return output;
        }

        #endregion
        
        #region AVG

        public static ContinuousValue<decimal> ContinuousAverage<T>(
            this ObservableCollection<T> input,
            Func<T, decimal> averageFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<decimal> output = new ContinuousValue<decimal>();
            new ContinuousAverageMonitorDecimal<T>(input, output, averageFunc);
            return output;
        }

        public static ContinuousValue<decimal> ContinuousAverage<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, decimal> averageFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<decimal> output = new ContinuousValue<decimal>();
            new ContinuousAverageMonitorDecimal<T>(input, output, averageFunc);
            return output;
        }

        public static ContinuousValue<float> ContinuousAverage<T>(
            this ObservableCollection<T> input,
            Func<T, float> averageFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<float> output = new ContinuousValue<float>();
            new ContinuousAverageMonitorFloat<T>(input, output, averageFunc);
            return output;
        }

        public static ContinuousValue<float> ContinuousAverage<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, float> averageFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<float> output = new ContinuousValue<float>();
            new ContinuousAverageMonitorFloat<T>(input, output, averageFunc);
            return output;
        }

        public static ContinuousValue<double> ContinuousAverage<T>(
            this ObservableCollection<T> input,
            Func<T, double> averageFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousAverageMonitorDouble<T>(input, output, averageFunc);
            return output;
        }

        public static ContinuousValue<double> ContinuousAverage<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, double> averageFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousAverageMonitorDouble<T>(input, output, averageFunc);
            return output;
        }

        public static ContinuousValue<double> ContinuousAverage<T>(
            this ObservableCollection<T> input,
            Func<T, int> averageFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousAverageMonitorDoubleInt<T>(input, output, averageFunc);
            return output;
        }

        public static ContinuousValue<double> ContinuousAverage<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, int> averageFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousAverageMonitorDoubleInt<T>(input, output, averageFunc);
            return output;
        }

        public static ContinuousValue<double> ContinuousAverage<T>(
            this ObservableCollection<T> input,
            Func<T, long> averageFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousAverageMonitorDoubleLong<T>(input, output, averageFunc);
            return output;
        }

        public static ContinuousValue<double> ContinuousAverage<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, long> averageFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousAverageMonitorDoubleLong<T>(input, output, averageFunc);
            return output;
        }

        #endregion

        #region MAX

        public static ContinuousValue<int> ContinuousMax<T>(
            this ObservableCollection<T> input,
            Func<T, int> maxFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<int> output = new ContinuousValue<int>();
            new ContinuousMaxMonitorInt<T>(input, output, maxFunc);
            return output;
        }

        public static ContinuousValue<int> ContinuousMax<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, int> maxFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<int> output = new ContinuousValue<int>();
            new ContinuousMaxMonitorInt<T>(input, output, maxFunc);
            return output;
        }

        public static ContinuousValue<double> ContinuousMax<T>(
            this ObservableCollection<T> input,
            Func<T, double> maxFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousMaxMonitorDouble<T>(input, output, maxFunc);
            return output;
        }

        public static ContinuousValue<double> ContinuousMax<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, double> maxFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousMaxMonitorDouble<T>(input, output, maxFunc);
            return output;
        }

        public static ContinuousValue<decimal> ContinuousMax<T>(
            this ObservableCollection<T> input,
            Func<T, decimal> maxFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<decimal> output = new ContinuousValue<decimal>();
            new ContinuousMaxMonitorDecimal<T>(input, output, maxFunc);
            return output;
        }

        public static ContinuousValue<decimal> ContinuousMax<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, decimal> maxFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<decimal> output = new ContinuousValue<decimal>();
            new ContinuousMaxMonitorDecimal<T>(input, output, maxFunc);
            return output;
        }

        public static ContinuousValue<float> ContinuousMax<T>(
            this ObservableCollection<T> input,
            Func<T, float> maxFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<float> output = new ContinuousValue<float>();
            new ContinuousMaxMonitorFloat<T>(input, output, maxFunc);
            return output;
        }

        public static ContinuousValue<float> ContinuousMax<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, float> maxFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<float> output = new ContinuousValue<float>();
            new ContinuousMaxMonitorFloat<T>(input, output, maxFunc);
            return output;
        }

        public static ContinuousValue<long> ContinuousMax<T>(
            this ObservableCollection<T> input,
            Func<T, long> maxFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<long> output = new ContinuousValue<long>();
            new ContinuousMaxMonitorLong<T>(input, output, maxFunc);
            return output;
        }

        public static ContinuousValue<long> ContinuousMax<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, long> maxFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<long> output = new ContinuousValue<long>();
            new ContinuousMaxMonitorLong<T>(input, output, maxFunc);
            return output;
        }

        #endregion

        #region STDDEV

        public static ContinuousValue<double> ContinuousStdDev<T>(
            this ObservableCollection<T> input,
            Func<T, int> columnSelector) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousStdDevMonitorInt<T>(input, output, columnSelector);
            return output;
        }

        public static ContinuousValue<double> ContinuousStdDev<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, int> columnSelector) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousStdDevMonitorInt<T>(input, output, columnSelector);
            return output;
        }

        public static ContinuousValue<double> ContinuousStdDev<T>(
            this ObservableCollection<T> input,
            Func<T, decimal> columnSelector) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousStdDevMonitorDecimal<T>(input, output, columnSelector);
            return output;
        }

        public static ContinuousValue<double> ContinuousStdDev<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, decimal> columnSelector) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousStdDevMonitorDecimal<T>(input, output, columnSelector);
            return output;
        }

        public static ContinuousValue<double> ContinuousStdDev<T>(
            this ObservableCollection<T> input,
            Func<T, float> columnSelector) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousStdDevMonitorFloat<T>(input, output, columnSelector);
            return output;
        }

        public static ContinuousValue<double> ContinuousStdDev<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, float> columnSelector) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousStdDevMonitorFloat<T>(input, output, columnSelector);
            return output;
        }

        public static ContinuousValue<double> ContinuousStdDev<T>(
            this ObservableCollection<T> input,
            Func<T, double> columnSelector) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousStdDevMonitorDouble<T>(input, output, columnSelector);
            return output;
        }

        public static ContinuousValue<double> ContinuousStdDev<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, double> columnSelector) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousStdDevMonitorDouble<T>(input, output, columnSelector);
            return output;
        }

        public static ContinuousValue<double> ContinuousStdDev<T>(
            this ObservableCollection<T> input,
            Func<T, long> columnSelector) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousStdDevMonitorLong<T>(input, output, columnSelector);
            return output;
        }

        public static ContinuousValue<double> ContinuousStdDev<T>(
            this ReadOnlyObservableCollection<T> input,
            Func<T, long> columnSelector) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            new ContinuousStdDevMonitorLong<T>(input, output, columnSelector);
            return output;
        }

        #endregion
    }
}
