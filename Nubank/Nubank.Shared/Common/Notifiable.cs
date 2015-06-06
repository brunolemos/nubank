using System;
using System.ComponentModel;

namespace Nubank.Common
{
    public class Notifiable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NotifyChanges()
        {
            NotifyPropertyChanged(String.Empty);
        }
    }
}
