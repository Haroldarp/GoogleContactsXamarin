using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace GoogleContactsXamarin.ViewModels
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
