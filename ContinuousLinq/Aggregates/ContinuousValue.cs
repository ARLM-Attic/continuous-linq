using System.ComponentModel;

namespace ContinuousLinq.Aggregates
{
    public sealed class ContinuousValue<T> : INotifyPropertyChanged
    {
        private T _realValue;

        internal object SourceAdapter
        { get; set; }
            
               
        public T CurrentValue
        {
            get
            {
                return _realValue;
            }
            internal set
            {
                _realValue = value;                               
                if (PropertyChanged != null)
                {                
                   PropertyChanged(this, new PropertyChangedEventArgs("CurrentValue"));
                }
            }
        }

        public override string ToString()
        {
            return _realValue.ToString();
        }

        public void Pause()
        {
            (SourceAdapter as IAggregateAdapter).Pause();
        }

        public void Resume()
        {
            (SourceAdapter as IAggregateAdapter).Resume();
        }

        public bool IsPaused
        {
            get
            {
                return (SourceAdapter as IAggregateAdapter).IsPaused;
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
