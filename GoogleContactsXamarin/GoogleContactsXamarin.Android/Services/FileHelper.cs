using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleContactsXamarin.Services;
using Xamarin.Forms;
using GoogleContactsXamarin.Droid.Services;
using System.IO;

[assembly: Dependency(typeof(FileHelper))]
namespace GoogleContactsXamarin.Droid.Services
{
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}