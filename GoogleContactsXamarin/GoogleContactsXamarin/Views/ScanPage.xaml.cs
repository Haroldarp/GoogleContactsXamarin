using GoogleContactsXamarin.Models;
using GoogleContactsXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace GoogleContactsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanPage : ContentPage
    {
        public ScanPage(Contact contact)
        {
            InitializeComponent();
            BindingContext = new ScanViewModel(contact);
        }

    }
}