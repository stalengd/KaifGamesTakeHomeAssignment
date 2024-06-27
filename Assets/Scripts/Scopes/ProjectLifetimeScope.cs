using UnityEngine;
using VContainer;
using VContainer.Unity;
using KaifGames.TestClicker.Bootstrapping;
using KaifGames.TestClicker.Monetary;
using KaifGames.TestClicker.ManualEarning;
using KaifGames.TestClicker.LevelProgression;
using KaifGames.TestClicker.Shop;

namespace KaifGames.TestClicker.Scopes
{
    public sealed class ProjectLifetimeScope : LifetimeScope
    {
        [SerializeField] private ShopItemsProvider _shopItemsProvider;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Bootstrap>(Lifetime.Singleton);

            builder.Register<Wallet>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<ManualEarner>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<ManualEarningPower>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<LevelProgress>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.RegisterInstance(_shopItemsProvider).AsImplementedInterfaces();
            builder.Register<ShopItemsInventory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<ShopItemPurchaser>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
