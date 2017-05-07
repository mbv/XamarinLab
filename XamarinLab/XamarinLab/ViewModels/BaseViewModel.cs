using XamarinLab.Helpers;
using XamarinLab.Services;

using Xamarin.Forms;

namespace XamarinLab.ViewModels
{
    public class BaseViewModel<T> : ObservableObject
    {
        /// <summary>
        /// Get the azure service instance
        /// </summary>
        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();

        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        private string _title = string.Empty;
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}

