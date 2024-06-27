namespace KaifGames.TestClicker.ManualEarning
{
    public sealed class ManualEarningPower : IManualEarningPower
    {
        public int MoneyPerClick
        {
            get => _moneyPerClick;
            set
            {
                var oldValue = _moneyPerClick;
                _moneyPerClick = value;
                MoneyPerClickChanged?.Invoke(oldValue, _moneyPerClick);
            }
        }

        public event System.Action<int, int> MoneyPerClickChanged;

        private int _moneyPerClick = 1;
    }
}