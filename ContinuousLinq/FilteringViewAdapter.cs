using System;
using System.ComponentModel;
using System.Diagnostics;

namespace ContinuousLinq
{
    internal sealed class FilteringViewAdapter<T> : ViewAdapter<T, T> where T : IEquatable<T>, INotifyPropertyChanged
    {
        private readonly Func<T, bool> _predicate;

        public FilteringViewAdapter(InputCollectionWrapper<T> input,
            ContinuousCollection<T> output,
            Func<T, bool> predicateFunc) : base(input, output)
        {
            Trace.WriteLine("[FVA] Init.");
            _predicate = predicateFunc;

            if (input.InnerAsList != null)
            {
                foreach (T item in input.InnerAsList)
                {
                    if (_predicate(item))
                        output.Add(item);
                }
            }
        }

        /// <summary>
        /// This method is used to re-evaluate whether a recently modified
        /// item still belongs in the collection or not.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="propertyName"></param>
        protected override void OnCollectionItemPropertyChanged(T item, string propertyName)
        {
            Trace.WriteLine("[FVA] (" + item + ") Property Changed : " + propertyName);
            if (_predicate != null)
            {
                if (!_predicate(item))
                {
                    _output.Remove(item);                    
                }
                else if (!_output.Contains(item))
                {
                    _output.Add(item);
                }
            }
        }
      
        protected override void AddItem(T newItem, int index)
        {
            SubscribeToItem(newItem);
            if (_predicate == null || _predicate(newItem))
            {
                _output.Add(newItem);
            }
        }

        protected override bool RemoveItem(T existingItem, int index)
        {
            UnsubscribeFromItem(existingItem);
            bool hadIt = _output.Remove(existingItem);
            return hadIt;
        }
    }
}
