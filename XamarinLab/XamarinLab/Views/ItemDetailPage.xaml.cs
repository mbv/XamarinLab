using System;
using XamarinLab.ViewModels;
using Xamarin.Forms;
using XamarinLab.Models;

namespace XamarinLab.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        private readonly ItemDetailViewModel _viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this._viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.LoadPositionsCommand.Execute(null);
        }

        void EditButton_Clicked(object sender, EventArgs e)
        {
            _viewModel.IsEditing = !_viewModel.IsEditing;
            if (_viewModel.IsEditing)
            {
                _viewModel.EditableItem = new Item
                {
                    Id = _viewModel.Item.Id,
                    Position = _viewModel.Item.Position,
                    Photo = _viewModel.Item.Photo,
                    Description = _viewModel.Item.Description
                };
            }
            else
            {
                _viewModel.Item.Id = _viewModel.EditableItem.Id;
                _viewModel.Item.Position = _viewModel.EditableItem.Position;
                _viewModel.Item.Photo = _viewModel.EditableItem.Photo;
                _viewModel.Item.Description = _viewModel.EditableItem.Description;
            }
            if (!_viewModel.IsEditing && _viewModel.IsCreating)
            {
                _viewModel.IsCreating = false;
                MessagingCenter.Send(this, "AddItem", _viewModel.Item);
            }
        }


        protected override bool OnBackButtonPressed()
        {
            if (_viewModel.IsEditing && !_viewModel.IsCreating)
            {
                _viewModel.IsEditing = false;
                return true;
            }
            return base.OnBackButtonPressed();
        }

        async void ChangePhotoButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemsPhoto(new ItemsPhotoViewModel(_viewModel.EditableItem)));
        }
    }
}