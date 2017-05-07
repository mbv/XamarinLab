using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinLab.Helpers;
using XamarinLab.Models;

namespace XamarinLab.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel<Position>
    {
        public Item Item { get; set; }

        private Item _editableItem;

        public Item EditableItem
        {
            get { return _editableItem; }
            set { SetProperty(ref _editableItem, value); }
        }

        private bool _isEditing = false;

        public bool IsEditing
        {
            get { return _isEditing; }
            set
            {
                if (_isEditing != value)
                {
                    SetProperty(ref _isEditing, value);
                    OnPropertyChanged("IsNotEditing");
                    OnPropertyChanged("EditButtonName");
                }
            }
        }

        private bool _isCreating = false;

        public bool IsCreating
        {
            get { return _isCreating; }
            set { SetProperty(ref _isCreating, value); }
        }

        public string EditButtonName => (IsEditing) ? "Save" : "Edit";

        public bool IsNotEditing => !_isEditing;

        public ObservableRangeCollection<Position> PositionItems { get; set; }
        public Command LoadPositionsCommand { get; set; }

        public ItemDetailViewModel(bool creating = false, Item item = null)
        {
            
            PositionItems = new ObservableRangeCollection<Position>();
            LoadPositionsCommand = new Command(async () => await ExecuteLoadPositionsCommand());
            Item = item;

            IsCreating = creating;
            if (IsCreating)
            {
                Item = new Item {Id = Guid.NewGuid().ToString(), PhotoId = "1", PositionId = "1"};
                EditableItem = Item;
                IsEditing = true;
            }
        }

        async Task ExecuteLoadPositionsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await DataStore.GetItemsAsync(true);
                if (PositionItems.Count != items.Count())
                {
                    for (int i = PositionItems.Count; i < items.Count(); i++)
                    {
                        var itemsList = new List<Position>(items);
                        PositionItems.Add(itemsList[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}