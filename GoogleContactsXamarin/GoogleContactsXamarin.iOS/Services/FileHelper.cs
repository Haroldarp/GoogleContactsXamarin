using Foundation;
using GoogleContactsXamarin.iOS.Services;
using GoogleContactsXamarin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(FileHelper))]
namespace GoogleContactsXamarin.iOS.Services
{
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, fileName);

        }
    }
}