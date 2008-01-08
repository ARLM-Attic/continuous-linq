using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ContinuousLinq
{
    internal class InputCollectionWrapper<T>
    {
        private readonly IList<T> _inner;
        private readonly ContinuousCollection<T> _innerAsCC;

        public InputCollectionWrapper(ObservableCollection<T> inner)
        {
            _inner = inner;
            _innerAsCC = inner as ContinuousCollection<T>;
        }

        public InputCollectionWrapper(ReadOnlyObservableCollection<T> inner)
        {
            _inner = inner;
        }

        public object SourceAdapter
        {
            get { return (_innerAsCC != null ? _innerAsCC.SourceAdapter : null); }
        }

        public INotifyCollectionChanged InnerAsNotifier
        {
             get { return (INotifyCollectionChanged)_inner; }
        }

        public IList<T> InnerAsList
        {
             get { return _inner; }
        }
    }
}
