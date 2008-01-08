using System;
using System.Collections.Generic;
using System.Linq;

namespace ContinuousLinq
{    
    public class GroupedContinuousCollection<TKey, TElement> :
        ContinuousCollection<TElement>, IGrouping<TKey, TElement>,
        IEquatable<GroupedContinuousCollection<TKey, TElement>>
    {
        private readonly TKey _key;
        private readonly IEqualityComparer<TKey> _comparer;

        internal GroupedContinuousCollection(TKey key, IEqualityComparer<TKey> comparer)
        {
            _key = key;
            _comparer = comparer;
        }

        #region IGrouping<TKey,TSource> Members

        public TKey Key
        {
            get { return _key; }
        }

        #endregion

        #region IEquatable<GroupedContinuousCollection<TSource,TKey>> Members

        public bool Equals(GroupedContinuousCollection<TKey, TElement> other)
        {
            return _comparer.Equals(this.Key, other.Key);
        }

        #endregion                  
    }
}
