namespace KaifGames.TestClicker.Monetary
{
    public sealed class Wallet : IWallet
    {
        public int MoneyAmount => _moneyAmount;

        public event System.Action<int, int> Changed;

        private int _moneyAmount = 0;

        public void AddMoney(int amount)
        {
            SetAmount(_moneyAmount + amount);
        }

        public bool CanSpend(int amount)
        {
            return _moneyAmount >= amount;
        }

        public bool TrySpend(int amount)
        {
            if (!CanSpend(amount))
            {
                return false;
            }
            SetAmount(_moneyAmount - amount);
            return true;
        }

        private void SetAmount(int amount)
        {
            var oldAmount = _moneyAmount;
            _moneyAmount = amount;
            Changed?.Invoke(oldAmount, amount);
        }
    }
}