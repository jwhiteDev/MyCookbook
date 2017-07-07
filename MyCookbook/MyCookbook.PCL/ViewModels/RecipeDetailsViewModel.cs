using MyCookbook.Data;
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
    public class RecipeDetailsViewModel
    {
        private string _recipeName;
        public string Name
        {
            get
            {
                return _recipeName;
            }
            set
            {
                if (value != null && _recipeName != value)
                {
                    _recipeName = value;
                    OnPropertyChanged();
                }
            }
        }

        public IList<IngredientData> IngredientList { get; set; }

        public RecipeDetailsViewModel()
        {
            IngredientList = new ObservableCollection<IngredientData>();
        }

        public RecipeDetailsViewModel(RecipeModel model)
        {
            this.Name = model.Title;
            IngredientList = new ObservableCollection<IngredientData>(model.Ingredients);
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
            Database_Old.SaveItem(new RecipeModel
            {
                Title = this._recipeName,
                Ingredients = this.IngredientList.ToList<IngredientData>()
            });

        }
    }
}
