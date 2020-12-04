using GoogleContactsXamarin.Models;
using GoogleContactsXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GoogleContactsXamarin.ViewModels
{
    class ContactViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; }
        public ObservableCollection<Contact> Contacts { get; set; }
        public ContactViewModel()
        {
            AddCommand = new Command(OnAdd);

            Contacts = new ObservableCollection<Contact>()
            {
                new Contact(){FirstName="Harold", LastName="Rodriguez"},
                new Contact(){FirstName="Axel", LastName="Rodriguez"},
                new Contact(){FirstName="Jose", LastName="Perez"},
                new Contact(){FirstName="Arlyn", LastName="Rodriguez"},
                new Contact(){FirstName="Maria", LastName="Perez"},
                new Contact(){FirstName="Harold", LastName="Rodriguez"},
                new Contact(){FirstName="Axel", LastName="Rodriguez"},
                new Contact(){FirstName="Jose", LastName="Perez"},
                new Contact(){FirstName="Arlyn", LastName="Rodriguez"},
                new Contact(){FirstName="Maria", LastName="Perez"},
                new Contact(){FirstName="Harold", LastName="Rodriguez"},
                new Contact(){FirstName="Axel", LastName="Rodriguez"},
                new Contact(){FirstName="Jose", LastName="Perez"},
                new Contact(){FirstName="Arlyn", LastName="Rodriguez"},
                new Contact(){FirstName="Maria", LastName="Perez"},
                new Contact(){FirstName="Harold", LastName="Rodriguez"},
                new Contact(){FirstName="Axel", LastName="Rodriguez"},
                new Contact(){FirstName="Jose", LastName="Perez"},
                new Contact(){FirstName="Arlyn", LastName="Rodriguez"},
                new Contact(){FirstName="Maria", LastName="Perez"},
                new Contact(){FirstName="Harold", LastName="Rodriguez"},
                new Contact(){FirstName="Axel", LastName="Rodriguez"},
                new Contact(){FirstName="Jose", LastName="Perez"},
                new Contact(){FirstName="Arlyn", LastName="Rodriguez"},
                new Contact(){FirstName="Maria", LastName="Perez"}
            };
        }

        public async void OnAdd()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddContactPage());
        }
    }
}
