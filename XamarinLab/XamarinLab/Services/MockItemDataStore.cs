using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using XamarinLab.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(XamarinLab.Services.MockItemDataStore))]
namespace XamarinLab.Services
{
    public class MockItemDataStore : IDataStore<Item>
    {
        private bool _isInitialized;
        private List<Item> _items;

        public async Task<bool> AddItemAsync(Item item)
        {
            await InitializeAsync();

            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = _items.FirstOrDefault(arg => arg.Id == item.Id);
            _items.Remove(_item);
            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = _items.FirstOrDefault(arg => arg.Id == item.Id);
            _items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(_items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
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

            this._items = new List<Item>();
            var _items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), PositionId = "1", PhotoId = "1", Description = "Torrent catfish candiru swallower surgeonfish. Sucker mackerel shark goatfish, taimen slender mola, masu salmon pygmy sunfish snakehead American sole noodlefish coelacanth stonefish quillback."},
                new Item { Id = Guid.NewGuid().ToString(), PositionId = "1", PhotoId = "2", Description = "Wolf-herring cherry salmon, lefteye flounder kelp perch. Molly Miller driftwood catfish scup sábalo, North American darter huchen shiner píntano nurse shark longfin lookdown catfish sand dab?"},
                new Item { Id = Guid.NewGuid().ToString(), PositionId = "3", PhotoId = "3", Description = "Rudderfish, mud catfish sand stargazer Pacific trout. Rainbow trout Antarctic cod elver flat loach bigmouth buffalo, false brotula: buffalofish. Atlantic saury rock cod Blobfish neon tetra."},
                new Item { Id = Guid.NewGuid().ToString(), PositionId = "2", PhotoId = "4", Description = "Quillfish elasmobranch yellowtail barramundi silver dollar delta smelt snipe eel longnose sucker sillago, \"coolie loach Devario hagfish.\""},
                new Item { Id = Guid.NewGuid().ToString(), PositionId = "2", PhotoId = "5", Description = "Seamoth round herring striped burrfish longfin escolar hillstream loach gulf menhaden coho salmon yellow-eye mullet angler catfish. "},
                new Item { Id = Guid.NewGuid().ToString(), PositionId = "3", PhotoId = "6", Description = "Crappie dogfish shark frogmouth catfish European minnow mud cat lined sole frogfish creek chub ocean perch suckermouth armored catfish, stonefish Spanish mackerel?"},
            };

            foreach (Item item in _items)
            {
                this._items.Add(item);
            }

            _isInitialized = true;
        }
    }
}
