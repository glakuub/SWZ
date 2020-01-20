using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.ViewModels
{
    public class NotificationBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] String property = null)
        {
            if(EqualityComparer<T>.Default.Equals(field,value))
            {
                return false;
            }
            field = value;
            RaisePropertyChanged(property);

            return true;
        }

        protected bool SetProperty<T>(T currentValue, T newValue, Action DoSet,
            [CallerMemberName] String property = null)
        {
            if (EqualityComparer<T>.Default.Equals(currentValue, newValue)) return false;
            DoSet.Invoke();
            RaisePropertyChanged(property);
            return true;
        }

        protected void RaisePropertyChanged([CallerMemberName] String property = null)
        {

            Debug.WriteLine("changed " + property);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            
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
        public T Model { get { return this_; } }
    }
}
