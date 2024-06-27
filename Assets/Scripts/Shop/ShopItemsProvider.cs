using System.Collections.Generic;
using UnityEngine;

namespace KaifGames.TestClicker.Shop
{
    [CreateAssetMenu(menuName = "Data/Shop/Items Provider")]
    public sealed class ShopItemsProvider : ScriptableObject, IShopItemsProvider
    {
        [SerializeField] private ShopItem[] _items;

        private readonly Dictionary<string, ShopItem> _itemsLookup = new();

        private void OnEnable()
        {
            foreach (var item in _items)
            {
                _itemsLookup[item.Id] = item;
            }
        }

        public IEnumerable<IShopItem> GetItems()
        {
            return _items;
        }

        public IShopItem GetItem(string id)
        {
            return _itemsLookup.GetValueOrDefault(id);
        }
    }
}
