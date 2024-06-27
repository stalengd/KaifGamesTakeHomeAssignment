using System;

namespace KaifGames.TestClicker.Monetary
{
    public interface IReadOnlyWallet
    {
        int MoneyAmount { get; }

        event Action<int, int> Changed;

        bool CanSpend(int amount);
    }
}