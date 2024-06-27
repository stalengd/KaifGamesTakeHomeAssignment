using KaifGames.TestClicker.Shop;

namespace KaifGames.TestClicker.UI.ShopWindow
{
    public sealed class ShopWindowItemPresenter 
    {
        public event System.Action<IShopItem> ItemClicked;

        private IShopItem _shopItem;
        private readonly ShopWindowItemView _view;

        public ShopWindowItemPresenter(ShopWindowItemView view)
        {
            _view = view;
        }

        public void Render(IShopItem item, bool isPurchased)
        {
            _shopItem = item;
            _view.SetActive(true);
            _view.SetName(item.Name);
            _view.SetIcon(item.Icon);
            _view.SetPurchased(isPurchased);
            _view.Clicked += OnItemClicked;
        }

        public void Hide()
        {
            _view.SetActive(false);
            _view.Clicked -= OnItemClicked;
        }

        private void OnItemClicked()
        {
            ItemClicked?.Invoke(_shopItem);
        }
    }
}
