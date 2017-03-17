using MyCookbook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCookbooks
{
    public class Database
    {
        private static List<RecipeModel> _db;
        public static List<RecipeModel> AppDatabase
        {
            get
            {
                if(_db==null)
                {
                    _db = new List<RecipeModel>();
                }
                return _db;
            }
        }
    }
}
