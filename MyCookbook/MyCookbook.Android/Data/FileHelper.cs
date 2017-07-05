using System;
using Xamarin.Forms;
using MyCookbook.Droid;
using MyCookbook.Data;
using System.IO;

[assembly: Dependency(typeof(FileHelper))]
namespace MyCookbook.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}