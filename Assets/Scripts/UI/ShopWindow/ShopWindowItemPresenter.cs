using KaifGames.TestClicker.Shop;

namespace KaifGames.TestClicker.UI.ShopWindow
{
    public sealed class ShopWindowItemPresenter 
    {
        private IShopItem _shopItem;
        private readonly ShopWindowItemView _view;

        public ShopWindowItemPresenter(ShopWindowItemView view)
        {
            _view = view;
        }

        public void Render(ShopItem shopItem)
        {
            _shopItem = shopItem;
            _view.SetActive(true);
            _view.SetName(shopItem.Name);
        }

        public void Hide()
        {
            _view.SetActive(false);
        }
    }
}
