using GoogleContactsXamarin.Models;
using GoogleContactsXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using Contact = GoogleContactsXamarin.Models.Contact;
using System.IO;
using GoogleContactsXamarin.Views;

namespace GoogleContactsXamarin.ViewModels
{
    class AddContactViewModel : BaseViewModel
    {
        public Contact Contact { get; set; }
        public bool HasPhoto { get; set; }
        public ICommand SaveCommad { get; }
        public ICommand ScanCommad { get; }
        public ICommand AddPhotoCommand { get; }
        public IList<string> PhoneLabels => new List<string>() { "No Label", "Mobile", "Work", "Home", "Main", "Work Fax", "Home Fax",
        "Pager","Other"};
        public IList<string> EmailLabels => new List<string>() { "No Label", "Work", "Home", "Main", "Other"};

        public AddContactViewModel(Contact contact = null)
        {
            HasPhoto = false;
            if(contact == null)
            {
                Contact = new Contact();
            }
            else
            {
                Contact = contact;
                if (!string.IsNullOrEmpty(Contact.PhotoPath))
                    HasPhoto = true;
            }

            SaveCommad = new Command(async () => await OnSaveAsync());
            ScanCommad = new Command(async () => await OnScanAsync());
            AddPhotoCommand = new Command(async () => await OnAddPhotoAsync());
        }

        public async Task OnSaveAsync()
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

        public async Task OnScanAsync()
        {
            await App.Current.MainPage.Navigation.PushAsync(new ScanPage(Contact));
        }

        public async Task OnAddPhotoAsync()
        {
            string option = await App.Current.MainPage.DisplayActionSheet("Change Photo", "Cancel", null, "Take Photo", "Choose Photo");
            bool result;
            switch (option)
            {
                case "Take Photo":
                    result = await OnTakePhotoAsync();
                    if (result)
                        HasPhoto = true;
                    break;

                case "Choose Photo":
                    result = await OnChoosePhotoAsync();
                    if (result)
                        HasPhoto = true;
                    break;

                default:
                    return;
            }
        }

        private async Task<bool> OnTakePhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                if (photo == null)
                    return false;

                Contact.PhotoPath = await SavePhotoAsync(photo);
                System.Diagnostics.Debug.Write($"Take Photo COMPLETED: {Contact.PhotoPath}");
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write($"Take Photo THREW: {ex.Message}");
                return true;
            }
        }

        private async Task<bool> OnChoosePhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                if (photo == null)
                    return false;

                Contact.PhotoPath = await SavePhotoAsync(photo);
                System.Diagnostics.Debug.Write($"Choose Photo COMPLETED: {Contact.PhotoPath}");
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write($"Choose Photo THREW: {ex.Message}");
                return false;
            }
        }

        private async Task<string> SavePhotoAsync(FileResult photo)
        {
            var newFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFilePath))
                await stream.CopyToAsync(newStream);

            return newFilePath;
        }
    }
}
