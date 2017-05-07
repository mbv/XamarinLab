using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using XamarinLab.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(XamarinLab.Services.MockPhotoDataStore))]
namespace XamarinLab.Services
{
    public class MockPhotoDataStore : IDataStore<Photo>
    {
        private bool _isInitialized;
        private List<Photo> _items;

        public async Task<bool> AddItemAsync(Photo item)
        {
            await InitializeAsync();

            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Photo item)
        {
            await InitializeAsync();

            var _item = _items.FirstOrDefault(arg => arg.Id == item.Id);
            _items.Remove(_item);
            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Photo item)
        {
            await InitializeAsync();

            var _item = _items.FirstOrDefault(arg => arg.Id == item.Id);
            _items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Photo> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(_items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Photo>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(_items);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            if (_isInitialized)
                return;

            this._items = new List<Photo>();
            var _items = new List<Photo>
            {
                new Photo { Id = "1", Name = "Konstantin Terekhov", Url = "https://pp.userapi.com/c604831/v604831893/4d6f7/usl1rP8KQqA.jpg"},
                new Photo { Id = "2", Name = "Ivan Shimko", Url = "https://pp.userapi.com/c620130/v620130589/1b56e/uVYYtQ8Rqao.jpg"},
                new Photo { Id = "3", Name = "Gennady Minenkov", Url = "https://pp.userapi.com/c630624/v630624049/4e436/2pwJKgPMDXA.jpg"},
                new Photo { Id = "4", Name = "Vladislav Savyonok", Url = "https://pp.userapi.com/c629327/v629327291/170e9/akrOsblcu4Y.jpg"},
                new Photo { Id = "5", Name = "Sergey Kozlovsky", Url = "https://pp.userapi.com/c628329/v628329862/3ed93/j7Bp0qjPvTE.jpg"},
                new Photo { Id = "6", Name = "Denis Al-Khelali", Url = "https://pp.userapi.com/c636916/v636916123/31ee1/Kf2NIgnQQlM.jpg"},
                new Photo { Id = "7", Name = "Nikita Gannusenko", Url = "https://pp.userapi.com/c621427/v621427410/6d2d/iAva1X5mDuc.jpg"},
                new Photo { Id = "8", Name = "Vladislav Doroshkevich", Url = "https://pp.userapi.com/c624325/v624325980/53cec/vw2Nbcl6afY.jpg"},
                new Photo { Id = "9", Name = "Princess Bubblegum", Url = "https://pp.userapi.com/c616725/v616725325/8e8c/y61vL6KPkSM.jpg"},
                new Photo { Id = "10", Name = "Pavel Bogushevich", Url = "https://pp.userapi.com/c636624/v636624288/64668/8VoHijt8f9Q.jpg"},
                //new Photo { Id = Guid.NewGuid().ToString(), Name = "", Url = ""},
            };

            foreach (var item in _items)
            {
                this._items.Add(item);
            }

            _isInitialized = true;
        }
    }
}
