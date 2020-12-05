using GoogleContactsXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GoogleContactsXamarin.ViewModels
{
    class AddContactViewModel : BaseViewModel
    {
        public Contact NewContact { get; set; }
        public ICommand SaveCommad { get; }

        public AddContactViewModel(Contact contact = null)
        {
            if(contact == null)
            {
                NewContact = new Contact();
            }
            else
            {
                NewContact = contact;
            }

            SaveCommad = new Command(async () => await OnSave());
        }

        public async Task OnSave()
        {
            if(string.IsNullOrWhiteSpace(NewContact.FirstName) || string.IsNullOrWhiteSpace(NewContact.PhoneNumber))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Los campos de nombre y numero son requeridos", "Ok");
                return;
            }
            await App.Database.SaveContactAsync(NewContact);
            await App.Current.MainPage.DisplayAlert("Guardado", $"El contacto {NewContact.FirstName} fue guardado en la agenda", "Ok");
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}
