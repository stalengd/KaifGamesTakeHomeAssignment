namespace KaifGames.TestClicker.UI.ShopItemPopup
{
    public sealed class ShopItemPopupPresenter 
    {
        private ShopItemPopupModel _model;
        private readonly ShopItemPopupView _view;

        public ShopItemPopupPresenter(ShopItemPopupView view)
        {
            _view = view;
        }

        public void Render(ShopItemPopupModel model)
        {
            _model = model;
            _view.SetActive(true);
            _view.SetName(model.Item.Name);
            _view.SetCost(model.Item.Cost);
            _view.SetClickPowerGain(model.Item.ClickPowerGain);
            _view.SetIcon(model.Item.Icon);
            _view.SetPurchasable(model.IsPurchasable);
            _view.BuyPressed += OnBuyPressed;
            _view.ExitPressed += OnExitPressed;
        }

        public void Hide()
        {
            _view.SetActive(false);
            _view.BuyPressed -= OnBuyPressed;
            _view.ExitPressed -= OnExitPressed;
        }

        private void OnBuyPressed()
        {
            _model.Purchase();
        }

        private void OnExitPressed()
        {
            _model.Exit();
        }
    }
}
