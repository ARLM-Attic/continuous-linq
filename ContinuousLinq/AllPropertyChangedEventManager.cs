using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;

namespace ContinuousLinq
{
    public class AllPropertyChangedEventManager : WeakEventManager
    {
        protected override void StartListening(object source)
        {
            INotifyPropertyChanged pSource = (INotifyPropertyChanged)source;
            pSource.PropertyChanged += HandlePropertyChanged;
        }

        protected override void StopListening(object source)
        {
            INotifyPropertyChanged pSource = (INotifyPropertyChanged)source;
            pSource.PropertyChanged -= HandlePropertyChanged;
        }

        public void HandlePropertyChanged(object source, PropertyChangedEventArgs args)
        {
            DeliverEvent(source, args);
        }

        public static void AddListener(object source, IWeakEventListener listener)
        {
            AllPropertyChangedEventManager currentMgr =
                AllPropertyChangedEventManager.CurrentManager;

            currentMgr.ProtectedAddListener(source, listener);
        }

        public static void RemoveListener(object source, IWeakEventListener listener)
        {
            AllPropertyChangedEventManager currentMgr =
                AllPropertyChangedEventManager.CurrentManager;

            currentMgr.ProtectedRemoveListener(source, listener);
        }

        protected static AllPropertyChangedEventManager CurrentManager
        {
            get
            {
                return (AllPropertyChangedEventManager)WeakEventManager.GetCurrentManager(
                    typeof(AllPropertyChangedEventManager));
            }
            set
            {
                WeakEventManager.SetCurrentManager(typeof(AllPropertyChangedEventManager),
                    value);
            }
        }
    }
}
