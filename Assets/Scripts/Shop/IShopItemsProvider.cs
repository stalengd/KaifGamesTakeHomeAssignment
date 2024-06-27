using System.Collections.Generic;

namespace KaifGames.TestClicker.Shop
{
    public interface IShopItemsProvider
    {
        IEnumerable<IShopItem> GetItems();
        IShopItem GetItem(string id);
    }
}