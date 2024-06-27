using System.Collections.Generic;
using KaifGames.TestClicker.ManualEarning;
using KaifGames.TestClicker.Saves;
using KaifGames.TestClicker.Saves.Models;

namespace KaifGames.TestClicker.Shop
{
    public sealed class ShopItemsInventory : IShopItemsInventory, ISaveHandler<ShopItemsInventorySaveData>
    {
        public event System.Action<IShopItem> ItemAdded;

        private readonly IManualEarningPower _manualEarningPower;
        private readonly IShopItemsProvider _shopItemsProvider;
        private readonly Dictionary<string, IShopItem> _purchasedItems = new();

        public ShopItemsInventory(IManualEarningPower manualEarningPower, IShopItemsProvider shopItemsProvider)
        {
            _manualEarningPower = manualEarningPower;
            _shopItemsProvider = shopItemsProvider;
        }

        public bool HasItem(string id)
        {
            return _purchasedItems.ContainsKey(id);
        }

        public bool TryAddItem(IShopItem item)
        {
            if (!_purchasedItems.TryAdd(item.Id, item))
            {
                return false;
            }
            _manualEarningPower.MoneyPerClick += item.ClickPowerGain;
            ItemAdded?.Invoke(item);
            return true;
        }

        public void WriteToSave(ShopItemsInventorySaveData data)
        {
            data.PurchasedItems.Clear();
            data.PurchasedItems.AddRange(_purchasedItems.Keys);
        }

        public void ReadFromSave(ShopItemsInventorySaveData data)
        {
            foreach (var itemId in data.PurchasedItems)
            {
                var item = _shopItemsProvider.GetItem(itemId);
                if (item == null)
                {
                    continue;
                }
                TryAddItem(item);
            }
        }
    }
}