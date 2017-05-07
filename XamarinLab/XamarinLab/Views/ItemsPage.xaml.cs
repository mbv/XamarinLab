using System;

using XamarinLab.Models;
using XamarinLab.ViewModels;

using Xamarin.Forms;

namespace XamarinLab.Views
{
    public partial class ItemsPage : ContentPage
    {
        private readonly ItemsPageViewModel _pageViewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _pageViewModel = new ItemsPageViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(false, item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(true)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_pageViewModel.Items.Count == 0)
                _pageViewModel.LoadItemsCommand.Execute(null);
        }
    }
}
