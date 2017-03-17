
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCookbook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeDetailView : ContentPage
    {
        private RecipeDetailViewModel vm;
        public RecipeDetailView()
        {
            InitializeComponent();
            vm = new RecipeDetailViewModel();
            this.BindingContext = vm;
        }

        void OnAddClicked(object sender, EventArgs args)
        {
            //add new item to list view
            vm.IngredientList.Add(new IngredientDetail());
            
        }

        void OnRemoveClicked(object sender, EventArgs args)
        {
            if(vm.IngredientList.Count > 0)
            {
                var length = vm.IngredientList.Count;
                vm.IngredientList.RemoveAt(length-1);
            }
        }

        void OnSaveClicked(object sender, EventArgs args)
        {
            vm.SaveData();
            Navigation.PopAsync();
        }

    }
}
