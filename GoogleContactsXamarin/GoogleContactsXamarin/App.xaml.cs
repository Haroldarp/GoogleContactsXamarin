using GoogleContactsXamarin.Data;
using GoogleContactsXamarin.Services;
using GoogleContactsXamarin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoogleContactsXamarin
{
    public partial class App : Application
    {
        private static ContactDatabase database;

        public static ContactDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ContactDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("contactdb.db3"));
                }
                return database;
            }
        }

        public App()
        {

            InitializeComponent();

            MainPage = new NavigationPage(new ContactPage())
            {
                BarBackgroundColor = Color.White,
                BarTextColor = Color.Black
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
