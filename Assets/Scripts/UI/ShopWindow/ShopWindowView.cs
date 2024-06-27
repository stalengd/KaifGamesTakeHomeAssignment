using UnityEngine;
using KaifGames.TestClicker.UI.Window;
using KaifGames.TestClicker.UI.Elements;
using KaifGames.TestClicker.UI.ShopItemPopup;

namespace KaifGames.TestClicker.UI.ShopWindow
{
    public sealed class ShopWindowView : WindowView
    {
        [SerializeField] private UIList<ShopWindowItemView> _items;
        [SerializeField] private ShopItemPopupView _itemPopup;

        public ShopItemPopupView ItemPopup => _itemPopup;

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public ShopWindowItemView AddItem()
        {
            return _items.CreateElement();
        }

        public ShopWindowItemView GetItem(int index)
        {
            return _items[index];
        }

        public void ClearItems()
        {
            _items.Clear();
        }
    }
}
