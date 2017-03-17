using MyCookbooks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCookbook
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeListView : ContentPage
    {
        private CookbookViewModel vm;
        public RecipeListView()
        {
            InitializeComponent();

            vm = new CookbookViewModel();
            this.BindingContext = vm;
        }

        async void OnAddClicked(object sender, EventArgs args)
        {
            //add new item to list view
            await Navigation.PushAsync(new RecipeDetailView());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.SyncData();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var recipe = e.SelectedItem as RecipeModel;

            Navigation.PushAsync(new RecipeDetailView
            {
                BindingContext = new RecipeDetailViewModel(recipe)
            });
        }
    }
}
