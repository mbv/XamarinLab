using System;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinLab.ViewModels;

namespace XamarinLab.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPosition : ContentPage
    {
        private readonly ItemsPositionViewModel _positionViewModel;

        public ItemsPosition()
        {
            InitializeComponent();
            BindingContext = _positionViewModel = new ItemsPositionViewModel();
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
            => ((ListView)sender).SelectedItem = null;

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

           // await DisplayAlert("Selected", e.SelectedItem.ToString(), "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_positionViewModel.Positions.Count == 0)
                _positionViewModel.LoadItemsCommand.Execute(null);
        }

        async void AddPosition_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new NewPositionPage());
        }
    
    }
}
