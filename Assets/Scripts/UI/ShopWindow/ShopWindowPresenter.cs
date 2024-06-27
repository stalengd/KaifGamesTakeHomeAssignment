using KaifGames.TestClicker.Shop;
using KaifGames.TestClicker.UI.Window;

namespace KaifGames.TestClicker.UI.ShopWindow
{
    public sealed class ShopWindowPresenter : WindowPresenter
    {
        private readonly ShopWindowView _view;
        private readonly IShopItemsProvider _shopItemsProvider;
        private readonly IShopItemPurchaser _shopItemPurchaser;
        private readonly IShopItemsInventory _shopItemsInventory;

        public ShopWindowPresenter(
            ShopWindowView view,
            IShopItemsProvider shopItemsProvider,
            IShopItemPurchaser shopItemPurchaser,
            IShopItemsInventory shopItemsInventory) : base(new())
        {
            _view = view;
            _shopItemsProvider = shopItemsProvider;
            _shopItemPurchaser = shopItemPurchaser;
            _shopItemsInventory = shopItemsInventory;
        }

        protected override void OnWindowActivated()
        {
            _view.SetActive(true);
            _shopItemsInventory.ItemAdded += OnItemAdded;
            Refresh();
        }

        protected override void OnWindowDeactivated()
        {
            _view.SetActive(false);
        }

        private void OnItemAdded(IShopItem item)
        {
            Refresh();
        }

        private void Refresh()
        {
            // Re-render whole stuff for now 
            _view.ClearItems();
            foreach (var item in _shopItemsProvider.GetItems())
            {
                var itemView = _view.AddItem();
                itemView.SetName(item.Name);
                itemView.SetIcon(item.Icon);
                itemView.SetPurchased(_shopItemsInventory.HasItem(item.Id));
                // Not the best solution because of capturing
                itemView.Clicked += () => OnItemClicked(item);
            }
        }

        private void OnItemClicked(IShopItem item)
        {
            _shopItemPurchaser.TryPurchase(item);
        }
    }
}
