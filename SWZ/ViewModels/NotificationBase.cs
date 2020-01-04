using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.ViewModels
{
    public class NotificationBase
    {
        public event PropertyChangedEventHandler propertyChanged;
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string property = null)
        {
            if(EqualityComparer<T>.Default.Equals(field,value))
            {
                return false;
            }
            field = value;
            RaisePropertyChanged(property);

            return true;
        }

        private void RaisePropertyChanged(string property)
        {
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
    public class NotificationBase<T>: NotificationBase where T: class, new()
    {
        protected T this_;

        public static implicit operator T(NotificationBase<T> thing) => thing.this_;

        public NotificationBase(T thing = null)
        {
            this_ = thing ?? new T();
        }
    }
}
