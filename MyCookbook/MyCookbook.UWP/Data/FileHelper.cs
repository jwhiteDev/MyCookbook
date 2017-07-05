using Windows.Storage;
using Xamarin.Forms;
using MyCookbook.UWP;
using System.IO;
using MyCookbook.Data;

[assembly: Dependency(typeof(FileHelper))]
namespace MyCookbook.UWP
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
