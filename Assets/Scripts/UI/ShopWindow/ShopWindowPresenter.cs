using System.Collections.Generic;
using KaifGames.TestClicker.Shop;
using KaifGames.TestClicker.UI.ShopItemPopup;
using KaifGames.TestClicker.UI.Window;

namespace KaifGames.TestClicker.UI.ShopWindow
{
    public sealed class ShopWindowPresenter : WindowPresenter
    {
        private readonly ShopWindowView _view;
        private readonly IShopItemsProvider _shopItemsProvider;
        private readonly IShopItemPurchaser _shopItemPurchaser;
        private readonly IShopItemsInventory _shopItemsInventory;

        private readonly List<ShopWindowItemPresenter> _itemPresenters = new();
        private readonly ShopItemPopupPresenter _itemPopupPresenter;

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
            _itemPopupPresenter = new(_view.ItemPopup);
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
            _itemPopupPresenter.Hide();
        }

        protected override void OnWindowDismount()
        {
            _shopItemsInventory.ItemAdded -= OnItemAdded;
            ClearPresenters();
        }

        private void Refresh()
        {
            // Re-render whole stuff for now 
            _view.ClearItems();
            ClearPresenters();
            foreach (var item in _shopItemsProvider.GetItems())
            {
                var itemView = _view.AddItem();
                var itemPresenter = new ShopWindowItemPresenter(itemView);
                itemPresenter.Render(item, _shopItemsInventory.HasItem(item.Id));
                itemPresenter.ItemClicked += OnItemClicked;
                _itemPresenters.Add(itemPresenter);
            }
        }

        private void ClearPresenters()
        {
            foreach (var item in _itemPresenters)
            {
                item.ItemClicked -= OnItemClicked;
                item.Hide();
            }
            _itemPresenters.Clear();
        }

        private void OnItemAdded(IShopItem item)
        {
            Refresh();
        }

        private void OnItemClicked(IShopItem item)
        {
            var popupModel = new ShopItemPopupModel(item, _shopItemPurchaser);
            popupModel.Purchased += OnItemPurchased;
            popupModel.Exited += OnPopupExited;
            _itemPopupPresenter.Render(popupModel);
        }

        private void OnItemPurchased()
        {
            _itemPopupPresenter.Hide();
        }

        private void OnPopupExited()
        {
            _itemPopupPresenter.Hide();
        }
    }
}
