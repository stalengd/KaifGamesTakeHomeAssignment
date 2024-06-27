namespace KaifGames.TestClicker.Monetary
{
    public interface IWallet : IReadOnlyWallet
    {
        void AddMoney(int amount);
        bool TrySpend(int amount);
    }
}