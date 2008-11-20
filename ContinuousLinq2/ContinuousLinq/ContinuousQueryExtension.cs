﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;
using ContinuousLinq.Collections;

namespace ContinuousLinq
{
    public static class ContinuousQueryExtension
    {
        #region Select

        public static ReadOnlyContinuousCollection<TResult> Select<TSource, TResult>(
            this ObservableCollection<TSource> source, Expression<Func<TSource, TResult>> selector)
        {
            return new SelectReadOnlyContinuousCollection<TSource, TResult>(source, selector);
        }

        public static ReadOnlyContinuousCollection<TResult> Select<TSource, TResult>(
            this ReadOnlyObservableCollection<TSource> source, Expression<Func<TSource, TResult>> selector)
        {
            return new SelectReadOnlyContinuousCollection<TSource, TResult>(source, selector);
        }

        public static ReadOnlyContinuousCollection<TResult> Select<TSource, TResult>(
            this ReadOnlyContinuousCollection<TSource> source, Expression<Func<TSource, TResult>> selector)
        {
            return new SelectReadOnlyContinuousCollection<TSource, TResult>(source, selector);
        }

        #endregion

        #region SelectMany

        public static ReadOnlyContinuousCollection<TResult> SelectMany<TSource, TResult>(
            this ObservableCollection<TSource> source, Expression<Func<TSource, IEnumerable<TResult>>> manySelector)
        {
            return new SelectManyReadOnlyContinuousCollection<TSource, TResult>(source, manySelector);
        }

        public static ReadOnlyContinuousCollection<TResult> SelectMany<TSource, TResult>(
            this ReadOnlyObservableCollection<TSource> source, Expression<Func<TSource, IEnumerable<TResult>>> manySelector)
        {
            return new SelectManyReadOnlyContinuousCollection<TSource, TResult>(source, manySelector);
        }

        public static ReadOnlyContinuousCollection<TResult> SelectMany<TSource, TResult>(
            this ReadOnlyContinuousCollection<TSource> source, Expression<Func<TSource, IEnumerable<TResult>>> manySelector)
        {
            return new SelectManyReadOnlyContinuousCollection<TSource, TResult>(source, manySelector);
        }

        #endregion

        #region Where

        public static ReadOnlyContinuousCollection<TSource> Where<TSource>(
            this ObservableCollection<TSource> source, Expression<Func<TSource, bool>> filter)
            where TSource : INotifyPropertyChanged
        {
            return new FilteringReadOnlyContinuousCollection<TSource>(source, filter);
        }

        public static ReadOnlyContinuousCollection<TSource> Where<TSource>(
            this ReadOnlyObservableCollection<TSource> source, Expression<Func<TSource, bool>> filter)
            where TSource : INotifyPropertyChanged
        {
            return new FilteringReadOnlyContinuousCollection<TSource>(source, filter);
        }

        public static ReadOnlyContinuousCollection<TSource> Where<TSource>(
            this ReadOnlyContinuousCollection<TSource> source, Expression<Func<TSource, bool>> filter)
            where TSource : INotifyPropertyChanged
        {
            return new FilteringReadOnlyContinuousCollection<TSource>(source, filter);
        }

        #endregion

        #region OrderBy

        public static OrderedReadOnlyContinuousCollection<TSource> OrderBy<TSource, TKey>(
            this ObservableCollection<TSource> source,
            Expression<Func<TSource, TKey>> keySelector)
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
        {
            return new SortingReadOnlyContinuousCollection<TSource, TKey>(source, keySelector, false);
        }

        public static OrderedReadOnlyContinuousCollection<TSource> OrderBy<TSource, TKey>(
            this ReadOnlyObservableCollection<TSource> source,
            Expression<Func<TSource, TKey>> keySelector)
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
        {
            return new SortingReadOnlyContinuousCollection<TSource, TKey>(source, keySelector, false);
        }

        public static OrderedReadOnlyContinuousCollection<TSource> OrderBy<TSource, TKey>(
            this ReadOnlyContinuousCollection<TSource> source,
            Expression<Func<TSource, TKey>> keySelector)
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
        {
            return new SortingReadOnlyContinuousCollection<TSource, TKey>(source, keySelector, false);
        }

        #endregion

        #region OrderByDescending

        public static OrderedReadOnlyContinuousCollection<TSource> OrderByDescending<TSource, TKey>(
           this ObservableCollection<TSource> source,
           Expression<Func<TSource, TKey>> keySelector)
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
        {
            return new SortingReadOnlyContinuousCollection<TSource, TKey>(source, keySelector, true);
        }

        public static OrderedReadOnlyContinuousCollection<TSource> OrderByDescending<TSource, TKey>(
            this ReadOnlyObservableCollection<TSource> source,
            Expression<Func<TSource, TKey>> keySelector)
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
        {
            return new SortingReadOnlyContinuousCollection<TSource, TKey>(source, keySelector, true);
        }

        public static OrderedReadOnlyContinuousCollection<TSource> OrderByDescending<TSource, TKey>(
            this ReadOnlyContinuousCollection<TSource> source,
            Expression<Func<TSource, TKey>> keySelector)
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
        {
            return new SortingReadOnlyContinuousCollection<TSource, TKey>(source, keySelector, true);
        }

        #endregion

        #region ThenBy

        public static ReadOnlyContinuousCollection<TSource> ThenBy<TSource, TKey>(      
            this OrderedReadOnlyContinuousCollection<TSource> source,
            Expression<Func<TSource, TKey>> keySelector)
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
        {
            return new ThenByReadOnlyContinuousCollection<TSource, TKey>(source, keySelector, false);
        }
        
        #endregion

        #region ThenByDescending

        public static ReadOnlyContinuousCollection<TSource> ThenByDescending<TSource, TKey>(
            this OrderedReadOnlyContinuousCollection<TSource> source,
            Expression<Func<TSource, TKey>> keySelector)
            where TSource : INotifyPropertyChanged
            where TKey : IComparable
        {
            return new ThenByReadOnlyContinuousCollection<TSource, TKey>(source, keySelector, true);
        }

        #endregion

        #region Distinct

        public static ReadOnlyContinuousCollection<TSource> Distinct<TSource>(
           this ObservableCollection<TSource> source)
        {
            return new DistinctReadOnlyContinuousCollection<TSource>(source);
        }

        public static ReadOnlyContinuousCollection<TSource> Distinct<TSource>(
            this ReadOnlyObservableCollection<TSource> source)
        {
            return new DistinctReadOnlyContinuousCollection<TSource>(source);
        }

        public static ReadOnlyContinuousCollection<TSource> Distinct<TSource>(
            this ReadOnlyContinuousCollection<TSource> source)
        {
            return new DistinctReadOnlyContinuousCollection<TSource>(source);
        }

        #endregion


        #region AsReadOnly

        public static ReadOnlyContinuousCollection<TSource> AsReadOnly<TSource>(
            this ObservableCollection<TSource> source)
        {
            return new PassThroughReadOnlyContinuousCollection<TSource>(source);
        }

        public static ReadOnlyContinuousCollection<TSource> AsReadOnly<TSource>(
            this ReadOnlyObservableCollection<TSource> source)
        {
            return new PassThroughReadOnlyContinuousCollection<TSource>(source);
        }

        #endregion

    }
}