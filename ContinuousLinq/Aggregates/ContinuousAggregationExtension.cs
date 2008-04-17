/*
 * Continuous Aggregation Extensions
 * Created by: Kevin Hoffman
 * Created on: April 16, 2008
 */
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
    public static class ContinuousAggregationExtension
    {
        #region SUM
        /// <summary>
        /// Invoke as 
        /// ContinuousValue<int> cAge = myQuery.ContinuousSum<int>( c => c.Age );
        /// </summary>
        /// <typeparam name="T"></typeparam>        
        /// <param name="input"></param>
        /// <param name="sumFunc"></param>
        /// <returns></returns>
        public static ContinuousValue<int> ContinuousSum<T>(
            this ObservableCollection<T> input,
            Func<T,int> sumFunc) where T: INotifyPropertyChanged
        {            
            ContinuousValue<int> output = new ContinuousValue<int>();                        
            ContinuousSumMonitorInt<T> sumMonitor = new ContinuousSumMonitorInt<T>(
                input, output, sumFunc);

            return output;
        }

        public static ContinuousValue<double> ContinuousSum<T>(
            this ObservableCollection<T> input,
            Func<T, double> sumFunc) where T: INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            ContinuousSumMonitorDouble<T> sumMonitor = new ContinuousSumMonitorDouble<T>(
                input, output, sumFunc);
            return output;
        }


        public static ContinuousValue<decimal> ContinuousSum<T>(
            this ObservableCollection<T> input,
            Func<T, decimal> sumFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<decimal> output = new ContinuousValue<decimal>();
            ContinuousSumMonitorDecimal<T> sumMonitor = new ContinuousSumMonitorDecimal<T>(
                input, output, sumFunc);
            return output;
        }


        public static ContinuousValue<float> ContinuousSum<T>(
            this ObservableCollection<T> input,
            Func<T, float> sumFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<float> output = new ContinuousValue<float>();
            ContinuousSumMonitorFloat<T> sumMonitor = new ContinuousSumMonitorFloat<T>(
                input, output, sumFunc);
            return output;
        }


        public static ContinuousValue<long> ContinuousSum<T>(
            this ObservableCollection<T> input,
            Func<T, long> sumFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<long> output = new ContinuousValue<long>();
            ContinuousSumMonitorLong<T> sumMonitor = new ContinuousSumMonitorLong<T>(
                input, output, sumFunc);
            return output;
        }

        public static ContinuousValue<int> ContinuousCount<T>(
            this ObservableCollection<T> input) where T: INotifyPropertyChanged
        {
            ContinuousValue<int> output = new ContinuousValue<int>();
            ContinuousCountMonitor<T> countMonitor =
                new ContinuousCountMonitor<T>(input, output);

            return output;
        }
        #endregion

        #region MIN
        public static ContinuousValue<int> ContinuousMin<T>(
            this ObservableCollection<T> input,
            Func<T, int> minFunc) where T: INotifyPropertyChanged
        {
            ContinuousValue<int> output = new ContinuousValue<int>();
            ContinuousMinMonitorInt<T> minMonitor =
                new ContinuousMinMonitorInt<T>(input, output, minFunc);
            return output;
        }

        public static ContinuousValue<double> ContinuousMin<T>(
            this ObservableCollection<T> input,
            Func<T, double> minFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            ContinuousMinMonitorDouble<T> minMonitor =
                new ContinuousMinMonitorDouble<T>(input, output, minFunc);
            return output;
        }

        public static ContinuousValue<decimal> ContinuousMin<T>(
            this ObservableCollection<T> input,
            Func<T, decimal> minFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<decimal> output = new ContinuousValue<decimal>();
            ContinuousMinMonitorDecimal<T> minMonitor =
                new ContinuousMinMonitorDecimal<T>(input, output, minFunc);
            return output;
        }

        public static ContinuousValue<float> ContinuousMin<T>(
            this ObservableCollection<T> input,
            Func<T, float> minFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<float> output = new ContinuousValue<float>();
            ContinuousMinMonitorFloat<T> minMonitor =
                new ContinuousMinMonitorFloat<T>(input, output, minFunc);
            return output;
        }

        public static ContinuousValue<long> ContinuousMin<T>(
            this ObservableCollection<T> input,
            Func<T, long> minFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<long> output = new ContinuousValue<long>();
            ContinuousMinMonitorLong<T> minMonitor =
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
            ContinuousAverageMonitorDecimal<T> avgMonitor =
                new ContinuousAverageMonitorDecimal<T>(input, output, averageFunc);
            return output;
        }

        public static ContinuousValue<float> ContinuousAverage<T>(
            this ObservableCollection<T> input,
            Func<T, float> averageFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<float> output = new ContinuousValue<float>();
            ContinuousAverageMonitorFloat<T> avgMonitor =
                new ContinuousAverageMonitorFloat<T>(input, output, averageFunc);
            return output;
        }

        public static ContinuousValue<double> ContinuousAverage<T>(
            this ObservableCollection<T> input,
            Func<T, double> averageFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            ContinuousAverageMonitorDouble<T> avgMonitor =
                new ContinuousAverageMonitorDouble<T>(input, output, averageFunc);
            return output;
        }

        public static ContinuousValue<double> ContinuousAverage<T>(
            this ObservableCollection<T> input,
            Func<T, int> averageFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            ContinuousAverageMonitorDoubleInt<T> avgMonitor =
                new ContinuousAverageMonitorDoubleInt<T>(input, output, averageFunc);
            return output;
        }

        public static ContinuousValue<double> ContinuousAverage<T>(
            this ObservableCollection<T> input,
            Func<T, long> averageFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            ContinuousAverageMonitorDoubleLong<T> avgMonitor =
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
            ContinuousMaxMonitorInt<T> maxMonitor =
                new ContinuousMaxMonitorInt<T>(input, output, maxFunc);
            return output;
        }

        public static ContinuousValue<double> ContinuousMax<T>(
           this ObservableCollection<T> input,
           Func<T, double> maxFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            ContinuousMaxMonitorDouble<T> maxMonitor =
                new ContinuousMaxMonitorDouble<T>(input, output, maxFunc);
            return output;
        }

        public static ContinuousValue<long> ContinuousMax<T>(
           this ObservableCollection<T> input,
           Func<T, long> maxFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<long> output = new ContinuousValue<long>();
            ContinuousMaxMonitorLong<T> maxMonitor =
                new ContinuousMaxMonitorLong<T>(input, output, maxFunc);
            return output;
        }

        public static ContinuousValue<float> ContinuousMax<T>(
           this ObservableCollection<T> input,
           Func<T, float> maxFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<float> output = new ContinuousValue<float>();
            ContinuousMaxMonitorFloat<T> maxMonitor =
                new ContinuousMaxMonitorFloat<T>(input, output, maxFunc);
            return output;
        }

        public static ContinuousValue<decimal> ContinuousMax<T>(
           this ObservableCollection<T> input,
           Func<T, decimal> maxFunc) where T : INotifyPropertyChanged
        {
            ContinuousValue<decimal> output = new ContinuousValue<decimal>();
            ContinuousMaxMonitorDecimal<T> maxMonitor =
                new ContinuousMaxMonitorDecimal<T>(input, output, maxFunc);
            return output;
        }
        #endregion

        #region STDDEV
        public static ContinuousValue<double> ContinuousStdDev<T>(
            this ObservableCollection<T> input,
            Func<T, int> columnSelector) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            ContinuousStdDevMonitorInt<T> stdDevMonitor =
                new ContinuousStdDevMonitorInt<T>(input, output, columnSelector);

            return output;
        }

        public static ContinuousValue<double> ContinuousStdDev<T>(
            this ObservableCollection<T> input,
            Func<T, decimal> columnSelector) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            ContinuousStdDevMonitorDecimal<T> stdDevMonitor =
                new ContinuousStdDevMonitorDecimal<T>(input, output, columnSelector);
            return output;
        }

        public static ContinuousValue<double> ContinuousStdDev<T>(
            this ObservableCollection<T> input,
            Func<T, float> columnSelector) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            ContinuousStdDevMonitorFloat<T> stdDevMonitor =
                new ContinuousStdDevMonitorFloat<T>(input, output, columnSelector);
            return output;
        }

        public static ContinuousValue<double> ContinuousStdDev<T>(
            this ObservableCollection<T> input,
            Func<T, double> columnSelector) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            ContinuousStdDevMonitorDouble<T> stdDevMonitor =
                new ContinuousStdDevMonitorDouble<T>(input, output, columnSelector);
            return output;
        }

        public static ContinuousValue<double> ContinuousStdDev<T>(
            this ObservableCollection<T> input,
            Func<T, long> columnSelector) where T : INotifyPropertyChanged
        {
            ContinuousValue<double> output = new ContinuousValue<double>();
            ContinuousStdDevMonitorLong<T> stdDevMonitor =
                new ContinuousStdDevMonitorLong<T>(input, output, columnSelector);
            return output;
        }

        #endregion
    }
}
