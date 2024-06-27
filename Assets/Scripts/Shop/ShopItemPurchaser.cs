using KaifGames.TestClicker.Monetary;

namespace KaifGames.TestClicker.Shop
{
    public sealed class ShopItemPurchaser : IShopItemPurchaser
    {
        private readonly IWallet _wallet;
        private readonly IShopItemsInventory _shopItemsInventory;

        public ShopItemPurchaser(IWallet wallet, IShopItemsInventory shopItemsInventory)
        {
            _wallet = wallet;
            _shopItemsInventory = shopItemsInventory;
        }

        public bool CanPurchase(IShopItem item)
        {
            if (_shopItemsInventory.HasItem(item.Id))
            {
                return false;
            }
            if (!_wallet.CanSpend(item.Cost))
            {
                return false;
            }
            return true;
        }

        public bool TryPurchase(IShopItem item)
        {
            if (!CanPurchase(item))
            {
                return false;
            }
            _wallet.TrySpend(item.Cost);
            _shopItemsInventory.TryAddItem(item);
            return true;
        }
    }
}