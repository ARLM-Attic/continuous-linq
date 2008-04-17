using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ContinuousLinq.Aggregates
{
    public sealed class ContinuousValue<T> : INotifyPropertyChanged
    {
        private T _realValue;

        public T CurrentValue
        {
            get
            {
                return _realValue;
            }
            set
            {
                _realValue = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentValue"));
                }
            }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
