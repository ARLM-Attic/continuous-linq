﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace ContinuousLinq.Aggregates
{
    public static class ContinuousAggregationExtension
    {
        #region SUM

        public static ContinuousValue<int> ContinuousSum<T>(
            this ObservableCollection<T> input,
            Expression<Func<T, int>> sumFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, int>(input, sumFunc, (list, selector) => list.Sum(selector));
        }

        public static ContinuousValue<double> ContinuousSum<T>(
            this ObservableCollection<T> input,
            Expression<Func<T, double>> sumFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, double>(input, sumFunc, (list, selector) => list.Sum(selector));
        }

        public static ContinuousValue<decimal> ContinuousSum<T>(
            this ObservableCollection<T> input,
            Expression<Func<T, decimal>> sumFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, decimal>(input, sumFunc, (list, selector) => list.Sum(selector));
        }

        public static ContinuousValue<float> ContinuousSum<T>(
            this ObservableCollection<T> input,
            Expression<Func<T, float>> sumFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, float>(input, sumFunc, (list, selector) => list.Sum(selector));
        }

        public static ContinuousValue<long> ContinuousSum<T>(
            this ObservableCollection<T> input,
            Expression<Func<T, long>> sumFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, long>(input, sumFunc, (list, selector) => list.Sum(selector));
        }

        public static ContinuousValue<int> ContinuousSum<T>(
            this ReadOnlyObservableCollection<T> input,
            Expression<Func<T, int>> sumFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, int>(input, sumFunc, (list, selector) => list.Sum(selector));
        }

        public static ContinuousValue<double> ContinuousSum<T>(
            this ReadOnlyObservableCollection<T> input,
            Expression<Func<T, double>> sumFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, double>(input, sumFunc, (list, selector) => list.Sum(selector));
        }

        public static ContinuousValue<decimal> ContinuousSum<T>(
            this ReadOnlyObservableCollection<T> input,
            Expression<Func<T, decimal>> sumFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, decimal>(input, sumFunc, (list, selector) => list.Sum(selector));
        }

        public static ContinuousValue<float> ContinuousSum<T>(
            this ReadOnlyObservableCollection<T> input,
            Expression<Func<T, float>> sumFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, float>(input, sumFunc, (list, selector) => list.Sum(selector));
        }

        public static ContinuousValue<long> ContinuousSum<T>(
            this ReadOnlyObservableCollection<T> input,
            Expression<Func<T, long>> sumFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, long>(input, sumFunc, (list, selector) => list.Sum(selector));
        }

        public static ContinuousValue<int> ContinuousSum<T>(
            this ReadOnlyContinuousCollection<T> input,
            Expression<Func<T, int>> sumFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, int>(input, sumFunc, (list, selector) => list.Sum(selector));
        }

        public static ContinuousValue<double> ContinuousSum<T>(
            this ReadOnlyContinuousCollection<T> input,
            Expression<Func<T, double>> sumFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, double>(input, sumFunc, (list, selector) => list.Sum(selector));
        }

        public static ContinuousValue<decimal> ContinuousSum<T>(
            this ReadOnlyContinuousCollection<T> input,
            Expression<Func<T, decimal>> sumFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, decimal>(input, sumFunc, (list, selector) => list.Sum(selector));
        }

        public static ContinuousValue<float> ContinuousSum<T>(
            this ReadOnlyContinuousCollection<T> input,
            Expression<Func<T, float>> sumFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, float>(input, sumFunc, (list, selector) => list.Sum(selector));
        }

        public static ContinuousValue<long> ContinuousSum<T>(
            this ReadOnlyContinuousCollection<T> input,
            Expression<Func<T, long>> sumFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, long>(input, sumFunc, (list, selector) => list.Sum(selector));
        }

        #endregion

        #region COUNT

        public static ContinuousValue<int> ContinuousCount<T>(
            this ObservableCollection<T> input) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, int>(input, null, (list, selector) => list.Count);
        }

        public static ContinuousValue<int> ContinuousCount<T>(
            this ReadOnlyObservableCollection<T> input) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, int>(input, null, (list, selector) => list.Count);
        }

        public static ContinuousValue<int> ContinuousCount<T>(
            this ReadOnlyContinuousCollection<T> input) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, int>(input, null, (list, selector) => list.Count);
        }

        #endregion

        #region MIN
        #region -- Int
        public static ContinuousValue<int> ContinuousMin<T>(
            this ObservableCollection<T> input,
            Expression<Func<T, int>> minFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, int>(input, minFunc, (list, selector) => list.Min(selector));
        }
        
        public static ContinuousValue<int> ContinuousMin<T>(
            this ReadOnlyObservableCollection<T> input,
            Expression<Func<T, int>> minFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, int>(input, minFunc, (list, selector) => list.Min(selector));
        }

        public static ContinuousValue<int> ContinuousMin<T>(
            this ReadOnlyContinuousCollection<T> input,
            Expression<Func<T, int>> minFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, int>(input, minFunc, (list, selector) => list.Min(selector));
        }
        #endregion

        #region -- Double
        public static ContinuousValue<double> ContinuousMin<T>(
            this ObservableCollection<T> input,
            Expression<Func<T, double>> minFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, double>(input, minFunc, (list, selector) => list.Min(selector));
        }
        public static ContinuousValue<double> ContinuousMin<T>(
            this ReadOnlyObservableCollection<T> input,
            Expression<Func<T, double>> minFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, double>(input, minFunc, (list, selector) => list.Min(selector));
        }
        public static ContinuousValue<double> ContinuousMin<T>(
            this ReadOnlyContinuousCollection<T> input,
            Expression<Func<T, double>> minFunc) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, double>(input, minFunc, (list, selector) => list.Min(selector));
        }
        #endregion

        #region -- Float
        public static ContinuousValue<float> ContinuousMin<T>(
            this ObservableCollection<T> input,
            Expression<Func<T, float>> minSelector) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, float>(input, minSelector, (list, selector) => list.Min(selector));
        }
        public static ContinuousValue<float> ContinuousMin<T>(
            this ReadOnlyObservableCollection<T> input,
            Expression<Func<T, float>> minSelector) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, float>(input, minSelector, (list, selector) => list.Min(selector));
        }
        public static ContinuousValue<float> ContinousMin<T>(
            this ReadOnlyContinuousCollection<T> input,
            Expression<Func<T, float>> minSelector) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, float>(input, minSelector, (list, selector) => list.Min(selector));
        }

        #endregion

        #region -- Long
        public static ContinuousValue<long> ContinuousMin<T>(
            this ObservableCollection<T> input,
            Expression<Func<T, long>> minSelector) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, long>(input, minSelector, (list, selector) => list.Min(selector));
        }
        public static ContinuousValue<long> ContinousMin<T>(
            this ReadOnlyObservableCollection<T> input,
            Expression<Func<T, long>> minSelector) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, long>(input, minSelector, (list, selector) => list.Min(selector));
        }
        public static ContinuousValue<long> ContinuousMin<T>(
            this ReadOnlyContinuousCollection<T> input,
            Expression<Func<T, long>> minSelector) where T : INotifyPropertyChanged
        {
            return new ContinuousValue<T, long>(input, minSelector, (list, selector) => list.Min(selector));
        }
        #endregion
        #endregion




        //#region AVG

        //public static ContinuousValue<decimal> ContinuousAverage<T>(
        //    this ObservableCollection<T> input,
        //    Expression<Func<T, decimal>> averageFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousAverageMonitorDecimal<T>(input, averageFunc).Value;
        //}

        //public static ContinuousValue<decimal> ContinuousAverage<T>(
        //    this ReadOnlyObservableCollection<T> input,
        //    Expression<Func<T, decimal>> averageFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousAverageMonitorDecimal<T>(input, averageFunc).Value;
        //}

        //public static ContinuousValue<float> ContinuousAverage<T>(
        //    this ObservableCollection<T> input,
        //    Expression<Func<T, float>> averageFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousAverageMonitorFloat<T>(input, averageFunc).Value;
        //}

        //public static ContinuousValue<float> ContinuousAverage<T>(
        //    this ReadOnlyObservableCollection<T> input,
        //    Expression<Func<T, float>> averageFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousAverageMonitorFloat<T>(input, averageFunc).Value;
        //}

        //public static ContinuousValue<double> ContinuousAverage<T>(
        //    this ObservableCollection<T> input,
        //    Expression<Func<T, double>> averageFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousAverageMonitorDouble<T>(input, averageFunc).Value;
        //}

        //public static ContinuousValue<double> ContinuousAverage<T>(
        //    this ReadOnlyObservableCollection<T> input,
        //    Expression<Func<T, double>> averageFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousAverageMonitorDouble<T>(input, averageFunc).Value;
        //}

        //public static ContinuousValue<double> ContinuousAverage<T>(
        //    this ObservableCollection<T> input,
        //    Expression<Func<T, int>> averageFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousAverageMonitorDoubleInt<T>(input, averageFunc).Value;
        //}

        //public static ContinuousValue<double> ContinuousAverage<T>(
        //    this ReadOnlyObservableCollection<T> input,
        //    Expression<Func<T, int>> averageFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousAverageMonitorDoubleInt<T>(input, averageFunc).Value;
        //}

        //public static ContinuousValue<double> ContinuousAverage<T>(
        //    this ObservableCollection<T> input,
        //    Expression<Func<T, long>> averageFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousAverageMonitorDoubleLong<T>(input, averageFunc).Value;
        //}

        //public static ContinuousValue<double> ContinuousAverage<T>(
        //    this ReadOnlyObservableCollection<T> input,
        //    Expression<Func<T, long>> averageFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousAverageMonitorDoubleLong<T>(input, averageFunc).Value;
        //}

        //#endregion

        //#region MAX

        //public static ContinuousValue<int> ContinuousMax<T>(
        //    this ObservableCollection<T> input,
        //    Expression<Func<T, int>> maxFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousMaxMonitorInt<T>(input, maxFunc).Value;
        //}

        //public static ContinuousValue<int> ContinuousMax<T>(
        //    this ReadOnlyObservableCollection<T> input,
        //    Expression<Func<T, int>> maxFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousMaxMonitorInt<T>(input, maxFunc).Value;
        //}

        //public static ContinuousValue<double> ContinuousMax<T>(
        //    this ObservableCollection<T> input,
        //    Expression<Func<T, double>> maxFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousMaxMonitorDouble<T>(input, maxFunc).Value;
        //}

        //public static ContinuousValue<double> ContinuousMax<T>(
        //    this ReadOnlyObservableCollection<T> input,
        //    Expression<Func<T, double>> maxFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousMaxMonitorDouble<T>(input, maxFunc).Value;
        //}

        //public static ContinuousValue<decimal> ContinuousMax<T>(
        //    this ObservableCollection<T> input,
        //    Expression<Func<T, decimal>> maxFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousMaxMonitorDecimal<T>(input, maxFunc).Value;
        //}

        //public static ContinuousValue<decimal> ContinuousMax<T>(
        //    this ReadOnlyObservableCollection<T> input,
        //    Expression<Func<T, decimal>> maxFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousMaxMonitorDecimal<T>(input, maxFunc).Value;
        //}

        //public static ContinuousValue<float> ContinuousMax<T>(
        //    this ObservableCollection<T> input,
        //    Expression<Func<T, float>> maxFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousMaxMonitorFloat<T>(input, maxFunc).Value;
        //}

        //public static ContinuousValue<float> ContinuousMax<T>(
        //    this ReadOnlyObservableCollection<T> input,
        //    Expression<Func<T, float>> maxFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousMaxMonitorFloat<T>(input, maxFunc).Value;
        //}

        //public static ContinuousValue<long> ContinuousMax<T>(
        //    this ObservableCollection<T> input,
        //    Expression<Func<T, long>> maxFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousMaxMonitorLong<T>(input, maxFunc).Value;
        //}

        //public static ContinuousValue<long> ContinuousMax<T>(
        //    this ReadOnlyObservableCollection<T> input,
        //    Expression<Func<T, long>> maxFunc) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousMaxMonitorLong<T>(input, maxFunc).Value;
        //}

        //#endregion

        //#region STDDEV

        //public static ContinuousValue<double> ContinuousStdDev<T>(
        //    this ObservableCollection<T> input,
        //    Expression<Func<T, int>> columnSelector) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousStdDevMonitorInt<T>(input, columnSelector).Value;
        //}

        //public static ContinuousValue<double> ContinuousStdDev<T>(
        //    this ReadOnlyObservableCollection<T> input,
        //    Expression<Func<T, int>> columnSelector) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousStdDevMonitorInt<T>(input, columnSelector).Value;
        //}

        //public static ContinuousValue<double> ContinuousStdDev<T>(
        //    this ObservableCollection<T> input,
        //    Expression<Func<T, decimal>> columnSelector) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousStdDevMonitorDecimal<T>(input, columnSelector).Value;
        //}

        //public static ContinuousValue<double> ContinuousStdDev<T>(
        //    this ReadOnlyObservableCollection<T> input,
        //    Expression<Func<T, decimal>> columnSelector) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousStdDevMonitorDecimal<T>(input, columnSelector).Value;
        //}

        //public static ContinuousValue<double> ContinuousStdDev<T>(
        //    this ObservableCollection<T> input,
        //    Expression<Func<T, float>> columnSelector) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousStdDevMonitorFloat<T>(input, columnSelector).Value;
        //}

        //public static ContinuousValue<double> ContinuousStdDev<T>(
        //    this ReadOnlyObservableCollection<T> input,
        //    Expression<Func<T, float>> columnSelector) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousStdDevMonitorFloat<T>(input, columnSelector).Value;
        //}

        //public static ContinuousValue<double> ContinuousStdDev<T>(
        //    this ObservableCollection<T> input,
        //    Expression<Func<T, double>> columnSelector) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousStdDevMonitorDouble<T>(input, columnSelector).Value;
        //}

        //public static ContinuousValue<double> ContinuousStdDev<T>(
        //    this ReadOnlyObservableCollection<T> input,
        //    Expression<Func<T, double>> columnSelector) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousStdDevMonitorDouble<T>(input, columnSelector).Value;
        //}

        //public static ContinuousValue<double> ContinuousStdDev<T>(
        //    this ObservableCollection<T> input,
        //    Expression<Func<T, long>> columnSelector) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousStdDevMonitorLong<T>(input, columnSelector).Value;
        //}

        //public static ContinuousValue<double> ContinuousStdDev<T>(
        //    this ReadOnlyObservableCollection<T> input,
        //    Expression<Func<T, long>> columnSelector) where T : INotifyPropertyChanged
        //{
        //    return new ContinuousStdDevMonitorLong<T>(input, columnSelector).Value;
        //}

        //#endregion
    }
}
