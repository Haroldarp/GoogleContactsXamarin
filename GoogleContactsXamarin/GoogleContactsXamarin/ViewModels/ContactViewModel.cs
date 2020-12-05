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
using GoogleContactsXamarin.Services;

namespace GoogleContactsXamarin.ViewModels
{
    class ContactViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ObservableCollection<GroupedItems<string,Contact>> GroupedContacts { get; set; }
        public ContactViewModel()
        {
            AddCommand = new Command( async () => await OnAdd());
            EditCommand = new Command<Contact>(async (contact) => await OnEdit(contact));
            DeleteCommand = new Command<Contact>( async (contact) => await OnDelete(contact));

            GetGroupedContacts();
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
            GetGroupedContacts();
        }

        private void GetGroupedContacts()
        {
            IList<Contact> contacts = new List<Contact>();
            Task.Run(async () => { contacts = await App.Database.GetContactsAsync(); }).Wait();


            IEnumerable<GroupedItems<string, Contact>> groupedContact = new GroupedItems<string, Contact>[0];
            if (contacts != null)
            {
                groupedContact = from c in contacts
                                 orderby c.FirstName
                                 group c by c.FirstName[0].ToString()
                                 into grouped
                                 select new GroupedItems<string, Contact>(grouped.Key, grouped);
            }

            GroupedContacts = new ObservableCollection<GroupedItems<string, Contact>>(groupedContact);
        }
    }
}
