using KaifGames.TestClicker.LevelProgression;
using KaifGames.TestClicker.Monetary;

namespace KaifGames.TestClicker.ManualEarning
{
    public sealed class ManualEarner : IManualEarner
    {
        private readonly IManualEarningPower _manualEarningPower;
        private readonly IWallet _wallet;
        private readonly ILevelProgress _levelProgress;

        public ManualEarner(IManualEarningPower manualEarningPower, IWallet wallet, ILevelProgress levelProgress)
        {
            _manualEarningPower = manualEarningPower;
            _wallet = wallet;
            _levelProgress = levelProgress;
        }

        public void Earn()
        {
            var amount = _manualEarningPower.MoneyPerClick;
            _wallet.AddMoney(amount);
            _levelProgress.AddExperience(amount);
        }
    }
}
