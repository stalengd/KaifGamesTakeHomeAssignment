using KaifGames.TestClicker.Shop;

namespace KaifGames.TestClicker.UI.ShopItemPopup
{
    public sealed class ShopItemPopupModel
    {
        public IShopItem Item { get; }
        public bool IsPurchasable => _shopItemPurchaser.CanPurchase(Item);

        public event System.Action Exited;
        public event System.Action Purchased;

        private readonly IShopItemPurchaser _shopItemPurchaser;

        public ShopItemPopupModel(IShopItem item, IShopItemPurchaser shopItemPurchaser)
        {
            Item = item;
            _shopItemPurchaser = shopItemPurchaser;
        }

        public void Purchase()
        {
            if (_shopItemPurchaser.TryPurchase(Item))
            {
                Purchased?.Invoke();
            }
        }

        public void Exit()
        {
            Exited?.Invoke();
        }
    }
}