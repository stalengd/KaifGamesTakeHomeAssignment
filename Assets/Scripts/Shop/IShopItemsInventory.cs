using System;

namespace KaifGames.TestClicker.Shop
{
    public interface IShopItemsInventory
    {
        event Action<IShopItem> ItemAdded;

        bool HasItem(string id);
        bool TryAddItem(IShopItem item);
    }
}