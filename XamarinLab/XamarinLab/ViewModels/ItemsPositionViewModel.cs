using System;
using System.Diagnostics;
using System.Threading.Tasks;

using XamarinLab.Helpers;
using XamarinLab.Models;
using XamarinLab.Views;

using Xamarin.Forms;

namespace XamarinLab.ViewModels
{
    public class ItemsPositionViewModel : BaseViewModel<Position>
    {
        public ObservableRangeCollection<Position> Positions { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsPositionViewModel()
        {
            Title = "Positions";
            Positions = new ObservableRangeCollection<Position>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewPositionPage, Position>(this, "AddPosition", async (obj, item) =>
            {
                var _item = item as Position;
                Positions.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Positions.Clear();
                var items = await DataStore.GetItemsAsync(true);
                Positions.ReplaceRange(items);
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