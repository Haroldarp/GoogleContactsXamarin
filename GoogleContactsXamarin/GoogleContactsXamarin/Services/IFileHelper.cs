using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleContactsXamarin.Services
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string fileName);
    }
}
