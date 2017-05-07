﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using XamarinLab.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(XamarinLab.Services.MockPositionDataStore))]
namespace XamarinLab.Services
{
    public class MockPositionDataStore : IDataStore<Position>
    {
        private bool _isInitialized;
        private List<Position> _items;

        public async Task<bool> AddItemAsync(Position item)
        {
            await InitializeAsync();

            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Position item)
        {
            await InitializeAsync();

            var _item = _items.FirstOrDefault(arg => arg.Id == item.Id);
            _items.Remove(_item);
            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Position item)
        {
            await InitializeAsync();

            var _item = _items.FirstOrDefault(arg => arg.Id == item.Id);
            _items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Position> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(_items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Position>> GetItemsAsync(bool forceRefresh = false)
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

            this._items = new List<Position>();
            var _items = new List<Position>
            {
                new Position { Id = "1", Name = "Director"},
                new Position { Id = "2", Name = "Salesmen"},
                new Position { Id = "3", Name = "Hz"},
            };

            foreach (var item in _items)
            {
                this._items.Add(item);
            }

            _isInitialized = true;
        }
    }
}
