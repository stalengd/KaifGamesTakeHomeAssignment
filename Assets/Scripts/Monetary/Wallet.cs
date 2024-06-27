using KaifGames.TestClicker.Saves;
using KaifGames.TestClicker.Saves.Models;

namespace KaifGames.TestClicker.Monetary
{
    public sealed class Wallet : IWallet, ISaveHandler<WalletSaveData>
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

        public void WriteToSave(WalletSaveData data)
        {
            data.MoneyAmount = _moneyAmount;
        }

        public void ReadFromSave(WalletSaveData data)
        {
            _moneyAmount = data.MoneyAmount;
        }

        private void SetAmount(int amount)
        {
            var oldAmount = _moneyAmount;
            _moneyAmount = amount;
            Changed?.Invoke(oldAmount, amount);
        }
    }
}