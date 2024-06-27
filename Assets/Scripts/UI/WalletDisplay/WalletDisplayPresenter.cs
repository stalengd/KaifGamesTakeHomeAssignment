using System;
using KaifGames.TestClicker.Monetary;

namespace KaifGames.TestClicker.UI.WalletDisplay
{
    public sealed class WalletDisplayPresenter : IDisposable
    {
        private readonly WalletDisplayView _view;
        private readonly IReadOnlyWallet _wallet;

        public WalletDisplayPresenter(WalletDisplayView view, IReadOnlyWallet wallet)
        {
            _view = view;
            _wallet = wallet;
        }

        public void Render()
        {
            _wallet.Changed += OnWalletChanged;
            _view.SetMoneyAmount(_wallet.MoneyAmount);
        }

        public void Dispose()
        {
            _wallet.Changed -= OnWalletChanged;
        }

        private void OnWalletChanged(int oldAmoun, int newAmount)
        {
            _view.SetMoneyAmount(newAmount);
        }
    }
}
