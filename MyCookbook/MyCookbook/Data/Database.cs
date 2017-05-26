using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCookbook.Data
{
    public class Database
    {
        private static List<RecipeModel> _db;
        public static List<RecipeModel> AppDatabase
        {
            get
            {
                if (_db == null)
                {
                    _db = new List<RecipeModel>();
                }
                return _db;
            }
        }

        internal static void SaveItem(RecipeModel recipeModel)
        {
            //we only want to add items that are new
            if(!_db.Contains(recipeModel))
            {
                _db.Add(recipeModel);
            }
        }
    }
}
