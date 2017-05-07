using System;
using System.Diagnostics;
using System.Threading.Tasks;

using XamarinLab.Helpers;
using XamarinLab.Models;
using XamarinLab.Views;

using Xamarin.Forms;

namespace XamarinLab.ViewModels
{
    public class ItemsPhotoViewModel : BaseViewModel<Photo>
    {
        public Item Item { get; set; }

        public ObservableRangeCollection<Photo> Photos { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsPhotoViewModel(Item item = null)
        {
            Title = "Photos";
            Photos = new ObservableRangeCollection<Photo>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            Item = item;
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Photos.Clear();
                var items = await DataStore.GetItemsAsync(true);
                Photos.ReplaceRange(items);
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