using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyCookbook.Data
{

    public class AppDatabase
    {
        private readonly SQLiteAsyncConnection _database;
        public string StatusMessage { get; set; }

        public AppDatabase(string dbpath)
        {
            _database = new SQLiteAsyncConnection(dbpath);
            _database.CreateTableAsync<RecipeModel>().Wait();
        }

        public Task<List<RecipeModel>> GetItemsAsync()
        {
            return _database.Table<RecipeModel>().ToListAsync();
        }

        public Task<RecipeModel> GetItemAsync(int id)
        {
            return _database.Table<RecipeModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveRecipeAsync(RecipeModel recipe)
        {
                if (recipe.Id != 0)
                {
                    return _database.UpdateAsync(recipe);
                }
                else
                {
                    return _database.InsertAsync(recipe);
                }

        }

        public Task<int> DeleteRecipeAsync(RecipeModel recipe)
        {
            return _database.DeleteAsync(recipe);
        }

        /*
        public async Task AddNewRecipe(RecipeModel recipe)
        {
            try
            {
                var result = await _database.InsertAsync(recipe).ConfigureAwait(continueOnCapturedContext: false);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", recipe.Title, ex.Message);
            }
        }
        */


    }
}
