﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Threading;
using System.Threading;

namespace ContinuousLinq.Aggregates
{
    public sealed class ContinuousValue<T> : INotifyPropertyChanged
    {
        private T _realValue;
        private Dispatcher _dispatcher;        

        public ContinuousValue()
        {
            _dispatcher = Dispatcher.FromThread(Thread.CurrentThread);
        }

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


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
