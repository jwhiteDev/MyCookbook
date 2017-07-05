using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyCookbook.Data
{
    public static  class DatabaseFactory
    {
        private static AppDatabase _database;
        public static AppDatabase Instance
        {
            get
            {
                return _database ?? (_database = new AppDatabase(DependencyService.Get<IFileHelper>()
                                                        .GetLocalFilePath("Recipes.db3")));
            }
        }
    }
}
