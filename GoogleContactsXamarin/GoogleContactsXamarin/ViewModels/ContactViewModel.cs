using GoogleContactsXamarin.Models;
using GoogleContactsXamarin.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace GoogleContactsXamarin.ViewModels
{
    class ContactViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ObservableCollection<Contact> Contacts { get; set; }
        public ContactViewModel()
        {
            AddCommand = new Command( async () => await OnAdd());
            EditCommand = new Command<Contact>(async (contact) => await OnEdit(contact));
            DeleteCommand = new Command<Contact>( async (contact) => await OnDelete(contact));

            GetContacts();
        }

        public async Task OnAdd()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddContactPage());
        }
        public async Task OnEdit(Contact contact)
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddContactPage(contact));
        }

        public async Task OnDelete(Contact contact)
        {
            await App.Database.DeleteContactAsync(contact);
            GetContacts();
        }

        private void GetContacts()
        {
            Task.Run(async () =>
            {
                IList<Contact> list = await App.Database.GetContactsAsync();
                Contacts = new ObservableCollection<Contact>(list.OrderBy(c => c.FullName));

            }).Wait();
        }
    }
}
