﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace ContinuousLinq.Collections
{
    public class GroupedReadOnlyContinuousCollection<TKey, TSource>
        : ReadOnlyAdapterContinuousCollection<TSource, TSource>, IGrouping<TKey, TSource>
    {
        internal ContinuousCollection<TSource> InternalCollection 
        {
            get { return (ContinuousCollection<TSource>)this.Source; } 
        }

        public GroupedReadOnlyContinuousCollection(TKey key)
            : base(new ContinuousCollection<TSource>(), null)
        {
            this.Key = key;
            this.NotifyCollectionChangedMonitor.CollectionChanged += OnSourceCollectionChanged;
        }

        void OnSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            base.FireCollectionChanged(args);
        }

        #region IGrouping<TKey,TSource> Members

        public TKey Key { get; private set; }

        #endregion

        public override TSource this[int index]
        {
            get { return this.Source[index]; }
            set { throw new AccessViolationException(); }
        }

        public override int Count
        {
            get { return this.Source.Count; }
        }
    }
}
