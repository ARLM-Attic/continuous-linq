using System;
using System.Collections.Generic;

namespace ContinuousLinq
{
    /// <summary>
    /// Many thanks to Oren @ the SLINQ project, this class is extremely useful
    /// and a huge time-saver
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class FuncComparer<TSource, TKey> : Comparer<TSource>
           where TKey : IComparable
    {
        private readonly Func<TSource, TKey> keyFunc;
        private readonly int multiplier = 1;

        public FuncComparer(Func<TSource, TKey> keyFunc, bool descending)
        {
            this.keyFunc = keyFunc;

            if (descending)
                multiplier = -1;
            else
                multiplier = 1;
        }

        public override int Compare(TSource x, TSource y)
        {
            return multiplier * keyFunc(x).CompareTo(keyFunc(y));
        }
    }
}
