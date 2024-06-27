using System;

namespace KaifGames.TestClicker.ManualEarning
{
    public interface IManualEarningPower
    {
        int MoneyPerClick { get; set; }

        event Action<int, int> MoneyPerClickChanged;
    }
}