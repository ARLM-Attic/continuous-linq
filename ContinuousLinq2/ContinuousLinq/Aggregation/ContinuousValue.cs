﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Collections.Specialized;

namespace ContinuousLinq.Aggregates
{
    public abstract class ContinuousValue
    {
        protected bool RequiresRefresh { get; set; }

        protected static List<ContinuousValue> _dirtiedSincePause = new List<ContinuousValue>();

        private static int _globalPauseCount = 0;
        protected static bool IsGloballyPaused
        {
            get { return _globalPauseCount > 0 ; }
        }
       
        internal static void GlobalPause()
        {
            _globalPauseCount++;
        }

        internal static void GlobalResume()
        {
            _globalPauseCount--;
            if (_globalPauseCount == 0)
            {
                ResumeDirtyValues(); 
            }
        }

        private static void ResumeDirtyValues()
        {
            foreach (ContinuousValue continuousValue in _dirtiedSincePause)
            {
                continuousValue.Refresh();
                continuousValue.RequiresRefresh = false;
            }
            _dirtiedSincePause.Clear();
        }

        protected void MarkForResume()
        {
            if (!this.RequiresRefresh)
            {
                _dirtiedSincePause.Add(this);
                this.RequiresRefresh = true;
            }
        }

        protected abstract void Refresh();        
    }

    public abstract class ContinuousValue<T> : ContinuousValue, INotifyPropertyChanged
    {
        private T _currentValue;
        public T CurrentValue
        {
            get { return _currentValue; }
            set
            {
                if (EqualityComparer<T>.Default.Equals(value, _currentValue))
                    return;

                _currentValue = value;

                OnPropertyChanged("CurrentValue");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }        
        

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

    internal class ContinuousValue<TSource, TColSelectorResult, TResult> : ContinuousValue<TResult> where TSource : INotifyPropertyChanged
    {
        internal IList<TSource> Source { get; set; }

        internal Func<TSource, TColSelectorResult> Selector { get; set; }

        internal Func<IList<TSource>, Func<TSource, TColSelectorResult>, TResult> AggregationOperation { get; set; }

        internal NotifyCollectionChangedMonitor<TSource> NotifyCollectionChangedMonitor { get; set; }

        public Action<TResult> AfterEffect { get; set; }

        internal ContinuousValue(
            IList<TSource> input, 
            Expression<Func<TSource, TColSelectorResult>> selectorExpression,
            Func<IList<TSource>, Func<TSource,TColSelectorResult>, TResult> aggregateOperation)
        {            
            this.Source = input;

            this.AggregationOperation = aggregateOperation;

            PropertyAccessTree propertyAccessTree = null;
            
            if (selectorExpression != null)
            {
                this.Selector = selectorExpression.Compile();
                propertyAccessTree = ExpressionPropertyAnalyzer.Analyze(selectorExpression);
            }

            this.NotifyCollectionChangedMonitor = new NotifyCollectionChangedMonitor<TSource>(propertyAccessTree, input);
            
            this.NotifyCollectionChangedMonitor.CollectionChanged += OnCollectionChanged;
            this.NotifyCollectionChangedMonitor.ItemChanged += OnItemChanged;
            
            Refresh();
        }

        internal ContinuousValue(
            IList<TSource> input,
            Expression<Func<TSource, TColSelectorResult>> selectorExpression,
            Func<IList<TSource>, Func<TSource, TColSelectorResult>, TResult> aggregateOperation,
            Action<TResult> afterEffect)
            : this(input, selectorExpression, aggregateOperation)
        {
            this.AfterEffect = afterEffect;
            this.AfterEffect(this.CurrentValue);
        }

        void OnItemChanged(INotifyPropertyChanged obj)
        {
            Refresh();
        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Move)
                return;

            Refresh();
        }

        protected override void Refresh()
        {
            if (IsGloballyPaused)
            {
                MarkForResume();
                return;
            }

            if (this.Source.Count == 0)
                this.CurrentValue = default(TResult);
            else
                this.CurrentValue = this.AggregationOperation(this.Source, this.Selector);

            if (this.AfterEffect != null)
                AfterEffect(this.CurrentValue);
        }
    }
}