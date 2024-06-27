using VContainer.Unity;
using KaifGames.TestClicker.UI.WindowsHost;
using KaifGames.TestClicker.UI.MainWindow;
using KaifGames.TestClicker.UI.ShopWindow;
using KaifGames.TestClicker.UI.WalletDisplay;

namespace KaifGames.TestClicker.UI
{
    public sealed class GamePresenter : IStartable
    {
        private readonly WindowsHostPresenter _windowsHostPresenter;
        private readonly MainWindowPresenter _mainWindowPresenter;
        private readonly ShopWindowPresenter _shopWindowPresenter;
        private readonly WalletDisplayPresenter _walletDisplayPresenter;

        public GamePresenter(
            WindowsHostPresenter windowsHostPresenter,
            MainWindowPresenter mainWindowPresenter,
            ShopWindowPresenter shopWindowPresenter,
            WalletDisplayPresenter walletDisplayPresenter)
        {
            _windowsHostPresenter = windowsHostPresenter;
            _mainWindowPresenter = mainWindowPresenter;
            _shopWindowPresenter = shopWindowPresenter;
            _walletDisplayPresenter = walletDisplayPresenter;   
        }

        public void Start()
        {
            var windowsModel = new WindowsHostModel();
            windowsModel.AddWindow(_mainWindowPresenter.WindowModel);
            windowsModel.AddWindow(_shopWindowPresenter.WindowModel);
            _windowsHostPresenter.Render(windowsModel);
            windowsModel.ActivateWindow(windowsModel.Windows[0]);

            _walletDisplayPresenter.Render();
        }
    }
}
