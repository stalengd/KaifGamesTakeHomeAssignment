using UnityEngine;
using VContainer;
using VContainer.Unity;
using KaifGames.TestClicker.UI;
using KaifGames.TestClicker.UI.MainWindow;
using KaifGames.TestClicker.UI.WindowsHost;
using KaifGames.TestClicker.UI.ShopWindow;
using KaifGames.TestClicker.UI.WalletDisplay;

namespace KaifGames.TestClicker.Scopes
{
    public sealed class GameLifetimeScope : LifetimeScope
    {
        [Header("UI")]
        [SerializeField] private WalletDisplayView _walletDisplayView;
        [SerializeField] private WindowsHostView _windowsHostView;
        [SerializeField] private MainWindowView _mainWindowView;
        [SerializeField] private ShopWindowView _shopWindowView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GamePresenter>(Lifetime.Transient);

            builder.RegisterInstance(_windowsHostView);
            builder.Register<WindowsHostPresenter>(Lifetime.Singleton);

            builder.RegisterInstance(_mainWindowView);
            builder.Register<MainWindowPresenter>(Lifetime.Singleton);

            builder.RegisterInstance(_shopWindowView);
            builder.Register<ShopWindowPresenter>(Lifetime.Singleton);

            builder.RegisterInstance(_walletDisplayView);
            builder.Register<WalletDisplayPresenter>(Lifetime.Singleton);
        }
    }
}
