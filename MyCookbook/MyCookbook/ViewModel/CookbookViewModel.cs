using MyCookbooks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCookbook
{
    public class CookbookViewModel
    {
        public IList<RecipeModel> MyRecipeList { get; set; }

        public CookbookViewModel()
        {
            MyRecipeList = new ObservableCollection<RecipeModel>();
        }

        internal void SyncData()
        {
            MyRecipeList.Clear();
            foreach(var r in Database.AppDatabase)
            {
                MyRecipeList.Add(r);
            }
        }
    }
}
