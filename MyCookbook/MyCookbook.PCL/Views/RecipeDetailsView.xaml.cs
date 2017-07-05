using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCookbook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeDetailsView : ContentPage
    {
        private RecipeDetailsViewModel vm;

        public RecipeDetailsView()
        {
            InitializeComponent();
            vm = new RecipeDetailsViewModel();
            this.BindingContext = vm;
        }

        public RecipeDetailsView(RecipeDetailsViewModel _vm)
        {
            InitializeComponent();
            vm = _vm;
            this.BindingContext = vm;
        }

        void OnAddClicked(object sender, EventArgs args)
        {
            //add new item to list view
            vm.IngredientList.Add(new IngredientData());

        }

        void OnRemoveClicked(object sender, EventArgs args)
        {
            if (vm.IngredientList.Count > 0)
            {
                var length = vm.IngredientList.Count;
                vm.IngredientList.RemoveAt(length - 1);
            }
        }

        void OnSaveClicked(object sender, EventArgs args)
        {
            vm.SaveData();
            Navigation.PopAsync();
        }
    }
}