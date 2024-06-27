using System.Collections.Generic;
using KaifGames.TestClicker.ManualEarning;

namespace KaifGames.TestClicker.Shop
{
    public sealed class ShopItemsInventory : IShopItemsInventory
    {
        public event System.Action<IShopItem> ItemAdded;

        private readonly IManualEarningPower _manualEarningPower;
        private readonly Dictionary<string, IShopItem> _purchasedItems = new();

        public ShopItemsInventory(IManualEarningPower manualEarningPower)
        {
            _manualEarningPower = manualEarningPower;
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
    }
}