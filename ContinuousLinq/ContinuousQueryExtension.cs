﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace ContinuousLinq
{
    /// <summary>
    /// This class and the adapter model was inspired by the SLINQ (http://www.codeplex.com/slinq) project
    /// The philosophical difference between this project and SLINQ and others like it is that the goal of 
    /// ContinuousLINQ is to support data binding to a continually changing result set based on a query that
    /// is continuously re-evaluated as changes occur in the original collection. Other libraries for continuous
    /// queries require the UI to poll the changing collection on a timer, which isn't as continuous as I like.
    /// </summary>
    public static class ContinuousQueryExtension
    {
        #region Where
        private static ContinuousCollection<T> Where<T>(
            InputCollectionWrapper<T> source, Func<T, bool> filterFunc) where T : INotifyPropertyChanged
        {
            Trace.WriteLine("Filtering Observable Collection.");
            ContinuousCollection<T> output = new ContinuousCollection<T>();
            new FilteringViewAdapter<T>(source, output, filterFunc);

            return output;            
        }

        public static ContinuousCollection<T> Where<T>(
            this ObservableCollection<T> source, Func<T, bool> filterFunc) where T : INotifyPropertyChanged
        {
            return Where(new InputCollectionWrapper<T>(source), filterFunc);            
        }
        public static ContinuousCollection<T> Where<T>(
            this ReadOnlyObservableCollection<T> source, Func<T, bool> filterFunc) where T :  INotifyPropertyChanged
        {
            return Where(new InputCollectionWrapper<T>(source), filterFunc);
        }
        #endregion

        #region OrderBy
        private static ContinuousCollection<TSource> OrderBy<TSource, TKey>(
            InputCollectionWrapper<TSource> source, Func<TSource, TKey> keySelector)
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
        {
            Trace.WriteLine("Ordering Observable Collection (Ascending).");
            ContinuousCollection<TSource> output = new ContinuousCollection<TSource>();
            new SortingViewAdapter<TSource>(
                source, output,
                new FuncComparer<TSource, TKey>(keySelector, false));

            return output;             
        }

        public static ContinuousCollection<TSource> OrderBy<TSource, TKey>(
            this ObservableCollection<TSource> source, Func<TSource, TKey> keySelector)
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
        {
            return OrderBy(new InputCollectionWrapper<TSource>(source), keySelector);
        }
        public static ContinuousCollection<TSource> OrderBy<TSource, TKey>(
            this ReadOnlyObservableCollection<TSource> source, Func<TSource, TKey> keySelector)
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
        {
            return OrderBy(new InputCollectionWrapper<TSource>(source), keySelector);
        }
        public static ContinuousCollection<TSource> ThenBy<TSource, TKey>(
            this ObservableCollection<TSource> source, Func<TSource, TKey> keySelector)
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
        {
            return OrderBy(source, keySelector);
        }
        public static ContinuousCollection<TSource> ThenBy<TSource, TKey>(
            this ReadOnlyObservableCollection<TSource> source, Func<TSource, TKey> keySelector)
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
        {
            return OrderBy(source, keySelector);
        }
        #endregion

        #region OrderByDescending
        private static ContinuousCollection<TSource> OrderByDescending<TSource, TKey>(
            InputCollectionWrapper<TSource> source, Func<TSource, TKey> keySelector)
            where TSource :  INotifyPropertyChanged
            where TKey : IComparable
        {
            Trace.WriteLine("Ordering Observable Collection (Descending).");
            ContinuousCollection<TSource> output = new ContinuousCollection<TSource>();
            new SortingViewAdapter<TSource>(
                source, output,
                new FuncComparer<TSource, TKey>(keySelector, true));
            return output;             
        }

        public static ContinuousCollection<TSource> OrderByDescending<TSource, TKey>(
            this ObservableCollection<TSource> source, Func<TSource, TKey> keySelector)
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
        {
            return OrderByDescending(new InputCollectionWrapper<TSource>(source), keySelector);
        }
        public static ContinuousCollection<TSource> OrderByDescending<TSource, TKey>(
            this ReadOnlyObservableCollection<TSource> source, Func<TSource, TKey> keySelector)
            where TSource :  INotifyPropertyChanged
            where TKey : IComparable
        {
            return OrderByDescending(new InputCollectionWrapper<TSource>(source), keySelector);
        }
        public static ContinuousCollection<TSource> ThenByDescending<TSource, TKey>(
            this ObservableCollection<TSource> source, Func<TSource, TKey> keySelector)
            where TSource :  INotifyPropertyChanged
            where TKey : IComparable
        {
            return OrderByDescending(source, keySelector);
        }
        public static ContinuousCollection<TSource> ThenByDescending<TSource, TKey>(
            this ReadOnlyObservableCollection<TSource> source, Func<TSource, TKey> keySelector)
            where TSource :  INotifyPropertyChanged
            where TKey : IComparable
        {
            return OrderByDescending(source, keySelector);
        }
        #endregion

        #region GroupBy
        private static ContinuousCollection<GroupedContinuousCollection<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
            InputCollectionWrapper<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer)

            where TSource :  INotifyPropertyChanged
            where TKey: IComparable
            
        {
            ContinuousCollection<GroupedContinuousCollection<TKey, TElement>> output =
                new ContinuousCollection<GroupedContinuousCollection<TKey, TElement>>();

            new GroupingViewAdapter<TSource, TKey, TElement>(source, output, keySelector, elementSelector, comparer);
            return output;
        }

        private static T IdentitySelector<T>(T input)
        {
            return input;
        }

        public static ContinuousCollection<GroupedContinuousCollection<TKey, TSource>> GroupBy<TSource, TKey>(
            this ObservableCollection<TSource> source,
            Func<TSource, TKey> keySelector)
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
        {
            return GroupBy(source, keySelector, (IEqualityComparer<TKey>)null);
        }
        
        public static ContinuousCollection<GroupedContinuousCollection<TKey, TSource>> GroupBy<TSource, TKey>(
            this ReadOnlyObservableCollection<TSource> source,
            Func<TSource, TKey> keySelector)
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
        {
            return GroupBy(source, keySelector, (IEqualityComparer<TKey>)null);
        }
        
        public static ContinuousCollection<GroupedContinuousCollection<TKey, TSource>> GroupBy<TSource, TKey>(
            this ObservableCollection<TSource> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> comparer)
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
        {
            Func<TSource, TSource> elementSelector = IdentitySelector<TSource>;
            return GroupBy(source, keySelector, elementSelector, comparer);
        }
        
        public static ContinuousCollection<GroupedContinuousCollection<TKey, TSource>> GroupBy<TSource, TKey>(
            this ReadOnlyObservableCollection<TSource> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> comparer)
            where TSource :  INotifyPropertyChanged
            where TKey : IComparable
        {
            Func<TSource, TSource> elementSelector = IdentitySelector<TSource>;
            return GroupBy(source, keySelector, elementSelector, comparer);
        }

        public static ContinuousCollection<GroupedContinuousCollection<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
            this ObservableCollection<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
            where TSource :  INotifyPropertyChanged
            where TKey : IComparable
        {
            return GroupBy(source, keySelector, elementSelector, null);
        }
        
        public static ContinuousCollection<GroupedContinuousCollection<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
            this ReadOnlyObservableCollection<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
            where TSource :  INotifyPropertyChanged
            where TKey : IComparable
        {
            return GroupBy(source, keySelector, elementSelector, null);
        }

        public static ContinuousCollection<GroupedContinuousCollection<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
            this ObservableCollection<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer)
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
        {
            return GroupBy(new InputCollectionWrapper<TSource>(source), keySelector, elementSelector, comparer);
        }
        
        public static ContinuousCollection<GroupedContinuousCollection<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
            this ReadOnlyObservableCollection<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer)
            where TSource :  INotifyPropertyChanged
            where TKey : IComparable
        {
            return GroupBy(new InputCollectionWrapper<TSource>(source), keySelector, elementSelector, comparer);
        }
        #endregion

        #region Select
        private static ContinuousCollection<TResult> Select<TSource, TResult>(
            InputCollectionWrapper<TSource> source, Func<TSource, TResult> selector)
            where TSource :  INotifyPropertyChanged
        {
            ContinuousCollection<TResult> output = new ContinuousCollection<TResult>();
            new SelectingViewAdapter<TSource, TResult>(source, output, selector);

            return output;
        }

        public static ContinuousCollection<TResult> Select<TSource, TResult>(
            this ObservableCollection<TSource> source, Func<TSource, TResult> selector)
            where TSource :  INotifyPropertyChanged
        {
            return Select(new InputCollectionWrapper<TSource>(source), selector);
        }

        public static ContinuousCollection<TResult> Select<TSource, TResult>(
            this ReadOnlyObservableCollection<TSource> source, Func<TSource, TResult> selector)
            where TSource : INotifyPropertyChanged
        {
            return Select(new InputCollectionWrapper<TSource>(source), selector);
        }
        #endregion

        #region SelectMany

        private static ContinuousCollection<TResult> SelectMany<TSource, TResult>(
            InputCollectionWrapper<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
            where TSource :  INotifyPropertyChanged
        {
            ContinuousCollection<TResult> output = new ContinuousCollection<TResult>();
            new SelectingManyViewAdapter<TSource, TResult>(source, output, selector);

            return output;
        }

        public static ContinuousCollection<TResult> SelectMany<TSource, TResult>(
            this ObservableCollection<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
            where TSource : INotifyPropertyChanged
        {
            return SelectMany(new InputCollectionWrapper<TSource>(source), selector);
        }
        public static ContinuousCollection<TResult> SelectMany<TSource, TResult>(
            this ReadOnlyObservableCollection<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
            where TSource :  INotifyPropertyChanged
        {
            return SelectMany(new InputCollectionWrapper<TSource>(source), selector);
        }
        #endregion
    }
}