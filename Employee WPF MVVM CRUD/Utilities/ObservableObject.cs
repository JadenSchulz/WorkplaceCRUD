using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Employee_WPF_MVVM_CRUD.Utilities
{
    /*
    * NAME : ObservableObject : INotifyPropertyChanged
    * DESCRIPTION: This class simplifies the process of data binding by implementing INotifyPropertyChanged in a way
    * that makes it both modify the property and automatically send a notifaction to the binding based on the property name
    */
    internal class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // Used to simplify changing + notifying
        public void ChangeBoundProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
        {
            property = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Used primarily for calculated properties
        public void NotifyPropertyChanged<T>(T property, [CallerArgumentExpression("property")] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
