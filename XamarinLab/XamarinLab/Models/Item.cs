using System;
using Xamarin.Forms;
using XamarinLab.Services;

namespace XamarinLab.Models
{
    public class Item : BaseDataObject
    {
        private IDataStore<Photo> PhotoDataStore => DependencyService.Get<IDataStore<Photo>>();
        private IDataStore<Position> PositionDataStore => DependencyService.Get<IDataStore<Position>>();

        private string _position = string.Empty;

        public Position Position
        {
            get { return PositionDataStore.GetItemAsync(_position).Result; }
            set { SetProperty(ref _position, value.Id); }
        }

        public string PositionId
        {
            set { SetProperty(ref _position, value); }
        }

        private string _photo = String.Empty;

        public string PhotoId
        {
            set { SetProperty(ref _photo, value); }
        }

        public Photo Photo
        {
            get { return PhotoDataStore.GetItemAsync(_photo).Result; }
            set { SetProperty(ref _photo, value.Id); }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public Item Clone()
        {
            return this.MemberwiseClone() as Item;
        }
    }
}