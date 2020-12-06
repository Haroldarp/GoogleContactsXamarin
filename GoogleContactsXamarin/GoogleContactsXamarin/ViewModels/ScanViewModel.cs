using GoogleContactsXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing;

namespace GoogleContactsXamarin.ViewModels
{
    class ScanViewModel : BaseViewModel
    {
        private Contact contact;
        public Result Result { get; set; }
        public bool IsScanning { get; set; }
        public bool IsAnalyzing { get; set; }
        public ICommand ScanComand { get; }
        public ScanViewModel(Contact contact)
        {
            this.contact = contact;

            IsAnalyzing = true;
            IsScanning = true;
            ScanComand = new Command(OnScan);
        }

        public void OnScan()
        {
            IsAnalyzing = false;
            IsScanning = false;

            Device.BeginInvokeOnMainThread(async () =>
            {
                string[] datos = Result.Text.Split('*');
                contact.FirstName = datos[0];
                contact.LastName = datos[1];
                contact.PhoneNumber = datos[2];

                await App.Current.MainPage.Navigation.PopAsync();
            });
        }


    }
}
