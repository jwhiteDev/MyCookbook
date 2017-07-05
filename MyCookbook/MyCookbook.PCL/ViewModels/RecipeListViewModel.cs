using MyCookbook.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCookbook
{
    public class RecipeListViewModel
    {
        public IList<RecipeModel> MyRecipeList { get; set; }

        public RecipeListViewModel()
        {
            MyRecipeList = new ObservableCollection<RecipeModel>();
        }

        internal void SyncData()
        {
            MyRecipeList.Clear();
            foreach (var r in Database_Old.AppDatabase)
            {
                MyRecipeList.Add(r);
            }
        }

        internal void RemoveItem(RecipeModel recipe)
        {
            MyRecipeList.Remove(recipe);
            Database_Old.AppDatabase.Remove(recipe);
        }

        internal void PopulateDummyData()
        {
            var recipe = new RecipeModel
            {
                Title = "Pancakes",
                Ingredients = new List<IngredientData>()
                
            };
            var recipe2 = new RecipeModel
            {
                Title = "Burgers",
                Ingredients = new List<IngredientData>()
            };
            Database_Old.AppDatabase.Add(recipe);
            Database_Old.AppDatabase.Add(recipe2);
        }
    }
}
