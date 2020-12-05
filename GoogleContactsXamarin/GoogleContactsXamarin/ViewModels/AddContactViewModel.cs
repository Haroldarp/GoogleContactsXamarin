using GoogleContactsXamarin.Models;
using GoogleContactsXamarin.Services;
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
        public Contact Contact { get; set; }
        public ICommand SaveCommad { get; }
        public IList<string> PhoneLabels => new List<string>() { "No Label", "Mobile", "Work", "Home", "Main", "Work Fax", "Home Fax",
        "Pager","Other"};
        public IList<string> EmailLabels => new List<string>() { "No Label", "Work", "Home", "Main", "Other"};

        public AddContactViewModel(Contact contact = null)
        {
            if(contact == null)
            {
                Contact = new Contact();
            }
            else
            {
                Contact = contact;
            }

            SaveCommad = new Command(async () => await OnSave());
        }

        public async Task OnSave()
        {
            if(string.IsNullOrWhiteSpace(Contact.FirstName) || string.IsNullOrWhiteSpace(Contact.PhoneNumber))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Los campos de nombre y numero son requeridos", "Ok");
                return;
            }
            Contact.ColorHex = ColorHelper.ColorHex;
            await App.Database.SaveContactAsync(Contact);
            await App.Current.MainPage.DisplayAlert("Guardado", $"El contacto {Contact.FirstName} fue guardado en la agenda", "Ok");
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}
