using System;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinLab.Models;
using XamarinLab.ViewModels;

namespace XamarinLab.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPhoto : ContentPage
    {
        private readonly ItemsPhotoViewModel _photoViewModel;

        public ItemsPhoto(ItemsPhotoViewModel photoViewModel)
        {
            InitializeComponent();
            BindingContext = _photoViewModel = photoViewModel;
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
            => ((ListView)sender).SelectedItem = null;

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            //await DisplayAlert("Selected", e.SelectedItem.ToString(), "OK");
            _photoViewModel.Item.Photo = e.SelectedItem as Photo;

            await Navigation.PopAsync(true);

            //Deselect Item
            //((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_photoViewModel.Photos.Count == 0)
                _photoViewModel.LoadItemsCommand.Execute(null);
        }
    
    }
}
