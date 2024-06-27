namespace KaifGames.TestClicker.Shop
{
    public interface IShopItemPurchaser
    {
        bool CanPurchase(IShopItem item);
        bool TryPurchase(IShopItem item);
    }
}