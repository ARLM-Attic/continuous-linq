using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace ContinuousLinq.Aggregates
{
    public static class StdDev
    {
        public static double Compute<T>(Func<T, int> columnSelector, ObservableCollection<T> dataList)
        {
            double finalValue = 0;
            double average = 0.0;
            double variance = 0.0;
            int count = 0;

            count = dataList.Count;
            average = dataList.Average(columnSelector);

            if (count == 0) return finalValue;

            for (int x = 0; x < count; x++)
            {
                int columnValue = columnSelector(dataList[x]);
                variance += Math.Pow(columnValue - average, 2);
            }

            finalValue = Math.Sqrt(variance / count);
            return finalValue;
        }

        public static double Compute<T>(Func<T, double> columnSelector, ObservableCollection<T> dataList)
        {
            double finalValue = 0;
            double average = 0.0;
            double variance = 0.0;
            int count = 0;

            count = dataList.Count;
            average = dataList.Average(columnSelector);

            if (count == 0) return finalValue;

            for (int x = 0; x < count; x++)
            {
                double columnValue = columnSelector(dataList[x]);
                variance += Math.Pow(columnValue - average, 2);
            }

            finalValue = Math.Sqrt(variance / count);
            return finalValue;
        }

        public static double Compute<T>(Func<T, float> columnSelector, ObservableCollection<T> dataList)
        {
            double finalValue = 0;
            double average = 0.0;
            double variance = 0.0;
            int count = 0;

            count = dataList.Count;
            average = dataList.Average(columnSelector);

            if (count == 0) return finalValue;

            for (int x = 0; x < count; x++)
            {
                float columnValue = columnSelector(dataList[x]);
                variance += Math.Pow(columnValue - average, 2);
            }

            finalValue = Math.Sqrt(variance / count);
            return finalValue;
        }

        public static double Compute<T>(Func<T, long> columnSelector, ObservableCollection<T> dataList)
        {
            double finalValue = 0;
            double average = 0.0;
            double variance = 0.0;
            int count = 0;

            count = dataList.Count;
            average = dataList.Average(columnSelector);

            if (count == 0) return finalValue;

            for (int x = 0; x < count; x++)
            {
                long columnValue = columnSelector(dataList[x]);
                variance += Math.Pow(columnValue - average, 2);
            }

            finalValue = Math.Sqrt(variance / count);
            return finalValue;
        }

        public static double Compute<T>(Func<T, decimal> columnSelector, ObservableCollection<T> dataList)
        {
            double finalValue = 0;
            double average = 0.0;
            double variance = 0.0;
            int count = 0;

            count = dataList.Count;
            average = (double)dataList.Average(columnSelector);

            if (count == 0) return finalValue;

            for (int x = 0; x < count; x++)
            {
                double columnValue = (double)columnSelector(dataList[x]);
                variance += Math.Pow(columnValue - average, 2);
            }

            finalValue = Math.Sqrt(variance / count);
            return finalValue;
        }
        
    }
}
