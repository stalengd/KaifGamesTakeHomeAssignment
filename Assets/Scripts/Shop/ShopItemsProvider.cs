using System.Collections.Generic;
using UnityEngine;

namespace KaifGames.TestClicker.Shop
{
    [CreateAssetMenu(menuName = "Data/Shop/Items Provider")]
    public sealed class ShopItemsProvider : ScriptableObject, IShopItemsProvider
    {
        [SerializeField] private ShopItem[] _items;

        public IEnumerable<IShopItem> GetItems()
        {
            return _items;
        }
    }
}
