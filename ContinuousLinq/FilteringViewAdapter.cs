﻿using System;
using System.ComponentModel;
using System.Diagnostics;

namespace ContinuousLinq
{
    /// <summary>
    /// The FilteringViewAdapter is a "plug" of sorts that connects an input collection and an output
    /// collection in a chain of continuous collections. If the LINQ statement that originally operated
    /// on a collection that invoked the ContinuousQueryExtension included a 'where' clause, then an FVA
    /// is used to monitor the input collection for changes and modify the outbound collection to contain
    /// only those items that pass the filter predicate (included in the LINQ query in the where clause)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal sealed class FilteringViewAdapter<T> : ViewAdapter<T, T> where T : INotifyPropertyChanged
    {
        private readonly Func<T, bool> _predicate;

        public FilteringViewAdapter(InputCollectionWrapper<T> input,
            ContinuousCollection<T> output,
            Func<T, bool> predicateFunc) : base(input, output)
        {
            Trace.WriteLine("[FVA] Init.");
            _predicate = predicateFunc;

            foreach (T item in input.InnerAsList)
            {
                if (_predicate(item))
                    output.Add(item);
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
      
        /// <summary>
        /// When an item is added to the inbound collection, set up a weak monitoring event
        /// handler to listen to changes to that item so that any change to the new item
        /// can cause the item to be re-evaluated against the predicate. If the item passes
        /// the predicate, then it belongs in the output collection.
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="index"></param>
        protected override void AddItem(T newItem, int index)
        {
            SubscribeToItem(newItem);
            if (_predicate == null || _predicate(newItem))
            {
                _output.Add(newItem);
            }
        }

        /// <summary>
        /// When an item is removed from the source collection, it needs to be removed from the
        /// outbound collection as well. Additionally, all event handlers related to listening for
        /// changes to that item need to be cleaned up.
        /// </summary>
        /// <param name="existingItem"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override bool RemoveItem(T existingItem, int index)
        {
            UnsubscribeFromItem(existingItem);
            bool hadIt = _output.Remove(existingItem);
            return hadIt;
        }
    }
}
