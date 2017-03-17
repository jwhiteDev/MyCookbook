using MyCookbooks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyCookbook
{
    public class RecipeDetailViewModel : INotifyPropertyChanged
    {
        private string _recipeName;
        public string RecipeName
        {
            get
            {
                return _recipeName; }
            set
            {
                if (value != null && _recipeName != value)
                {
                    _recipeName = value;
                    OnPropertyChanged();
                }
            }
        }

        public IList<IngredientDetail> IngredientList { get; set; }

        public RecipeDetailViewModel()
        {
            IngredientList = new ObservableCollection<IngredientDetail>();
            //IngredientList.Add(new IngredientDetail());
            // = "Pancake";
        }

        public RecipeDetailViewModel(RecipeModel model)
        {
            this.RecipeName = model.Title;
            IngredientList = model.Ingredients.ToList<IngredientDetail>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            var handle = PropertyChanged;
            handle?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        internal void SaveData()
        {
            //TODO add validation
            Database.AppDatabase.Add(new RecipeModel
            {
                Title = this._recipeName,
                Ingredients = this.IngredientList.ToList<IngredientDetail>()
            });

        }
    }
}
