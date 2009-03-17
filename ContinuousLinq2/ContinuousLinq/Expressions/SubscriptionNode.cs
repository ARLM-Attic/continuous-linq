using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.ComponentModel;
using System.Windows;
using System.Collections;
using ContinuousLinq.WeakEvents;

namespace ContinuousLinq
{
    internal class SubscriptionNode 
    {
        private INotifyPropertyChanged _subject;

        internal PropertyAccessTreeNode AccessNode { get; set; }

        internal PropertyAccessNode PropertyAccessNode
        {
            get { return (PropertyAccessNode)this.AccessNode; }
        }

        internal List<SubscriptionNode> Children { get; set; }

        public INotifyPropertyChanged Subject
        {
            get { return _subject; }
            set
            {
                Unsubscribe();

                _subject = value;

                Subscribe();
            }
        }
        
        public event Action PropertyChanged;

        private void Subscribe()
        {
            INotifyPropertyChanged subject = this.Subject;
            if (subject == null)
                return;

            for (int i = 0; i < this.AccessNode.Children.Count; i++)
            {
                PropertyAccessNode propertyNode = (PropertyAccessNode)this.AccessNode.Children[i];

                WeakPropertyChangedEventManager.Register(
                    subject,
                    propertyNode.Property.Name,
                    this,
                    (me, sender, args) => me.OnPropertyChanged(sender, args));
            }

            if (this.Children != null)
            {
                for (int i = 0; i < this.Children.Count; i++)
                {
                    this.Children[i].UpdateSubject(subject);
                }
            }
        }
        
        private void UpdateSubject(INotifyPropertyChanged parentSubject)
        {
            if (parentSubject == null)
                this.Subject = null;

            //this.Subject = (INotifyPropertyChanged)this.PropertyAccessNode.Property.GetValue(parentSubject, null);
            //INotifyPropertyChanged first = (INotifyPropertyChanged)this.PropertyAccessNode.Property.GetValue(parentSubject, null);
            //INotifyPropertyChanged second = (INotifyPropertyChanged)this.PropertyAccessNode.GetPropertyValue(parentSubject); 
            //if (first != second)
            //{
            //    throw new Exception(string.Format("{0}\n\n{1}", first, second));
            //}

            this.Subject = (INotifyPropertyChanged)this.PropertyAccessNode.GetPropertyValue(parentSubject);
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (this.Children != null)
            {
                var nodeMatchingPropertyName = this.Children.FirstOrDefault(node => node.PropertyAccessNode.Property.Name == args.PropertyName);
                
                if (nodeMatchingPropertyName == null)
                    return;

                nodeMatchingPropertyName.UpdateSubject(this.Subject);
            }

            if (PropertyChanged == null)
                return;

            PropertyChanged();
        }

        private void Unsubscribe()
        {
            INotifyPropertyChanged subject = this.Subject;
            if (subject == null)
                return;

            for (int i = 0; i < this.AccessNode.Children.Count; i++)
            {
                PropertyAccessNode propertyNode = (PropertyAccessNode)this.AccessNode.Children[i];
               
                WeakPropertyChangedEventManager.Unregister(subject, propertyNode.Property.Name, this);
            }
            
            if (this.Children != null)
            {
                foreach (SubscriptionNode child in this.Children)
                {
                    child.Unsubscribe();
                }
            }
        }
      }
}
