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
    public partial class RecipeListView : ContentPage
    {
        private RecipeListViewModel vm;
        public RecipeListView()
        {
            InitializeComponent();

            vm = new RecipeListViewModel();
            vm.PopulateDummyData();
            this.BindingContext = vm;
        }

        async void OnAddClicked(object sender, EventArgs args)
        {
            //add new item to list view
            await Navigation.PushAsync(new RecipeDetailsView());
        }

        async void OnDelete(object sender, EventArgs args)
        {
            var mi = ((MenuItem)sender);
            var recipe = ((RecipeModel)mi.CommandParameter);
            vm.RemoveItem(recipe);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.SyncData();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null)
                return;

            var recipe = e.SelectedItem as RecipeModel;
            Navigation.PushAsync(new RecipeDetailsView(new RecipeDetailsViewModel(recipe)));
            //Clear the selected item
            ((ListView)sender).SelectedItem = null;
        }
    }
}