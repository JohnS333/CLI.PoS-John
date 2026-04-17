using CLI.PoS.Model;
using Library.PoS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Maui.PoS.ViewModels
{
    public class AdminMainViewViewModel: INotifyPropertyChanged
    {
        // InotifyPropertyChanged is an interface. Having it on the right of this semicolon means this class implements the interface.
        // When a class implements an interface, it agrees to a contract. The interface dictates a specific set of members that MUST exist
        // INotifyPropertyChanged interface requires any class that implements it to contain an event named PropertyChanged
        public ObservableCollection<Item> Items
        {
            get
            {
                return new ObservableCollection<Item>(ItemServiceProxy.Current.Items);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
            // this event comes from the INotifyPropertyChanged interface,
            // "PropertyChangedEventHandler" is a built in delegate type in .NET. it comes from the System.ComponentModel namespace
            // a delegate in C# is a type that defines a specifci method signature.
            //    In this case, PropertyChangedEventHandler dictates the shape of any method that wants to subscribe to (or "listen" to) the PropertyChanged event.
            //Specifically, it requires that the handling method must take two parameters:
            //1.	object? sender: The object that triggered the event (in this case, your ViewModel).
            //2.	PropertyChangedEventArgs e: An object containing the event data (specifically, the name of the property that changed).
            // "Any method that wants to be attached to this event MUST accept two inputs (parameters): one object (the sender), and one PropertyChangedEventArgs (the event data)."

    public void Refresh()
        {
            NotifyPropertyChanged("Items");
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
