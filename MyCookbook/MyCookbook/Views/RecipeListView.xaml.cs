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
            this.BindingContext = vm;
        }

        async void OnAddClicked(object sender, EventArgs args)
        {
            //add new item to list view
            await Navigation.PushAsync(new RecipeDetailsView());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.SyncData();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var recipe = e.SelectedItem as RecipeModel;

            Navigation.PushAsync(new RecipeDetailsView(new RecipeDetailsViewModel(recipe)));
        }
    }
}