using KaifGames.TestClicker.LevelProgression;
using KaifGames.TestClicker.ManualEarning;
using KaifGames.TestClicker.UI.Window;

namespace KaifGames.TestClicker.UI.MainWindow
{
    public sealed class MainWindowPresenter : WindowPresenter
    {
        private readonly MainWindowView _view;
        private readonly IManualEarner _manualEarner;
        private readonly IManualEarningPower _manualEarningPower;
        private readonly IReadOnlyLevelProgress _levelProgress;

        public MainWindowPresenter(
            MainWindowView view,
            IManualEarner manualEarner,
            IManualEarningPower manualEarningPower,
            IReadOnlyLevelProgress levelProgress) : base(new())
        {
            _view = view;
            _manualEarner = manualEarner;
            _manualEarningPower = manualEarningPower;
            _levelProgress = levelProgress;
        }

        protected override void OnWindowActivated()
        {
            _view.SetActive(true);
            _view.SetExperience(_levelProgress.CurrentExperience, _levelProgress.ExperienceToLevelUp);
            _view.SetLevel(_levelProgress.CurrentLevel);
            _view.SetClickPower(_manualEarningPower.MoneyPerClick);
            _view.EarnClicked += OnEarnClicked;
            _levelProgress.LevelChanged += OnLevelChanged;
            _levelProgress.ExperienceAdded += OnExperienceAdded;
            _manualEarningPower.MoneyPerClickChanged += OnMoneyPerClickChanged;
        }

        protected override void OnWindowDeactivated()
        {
            _view.SetActive(false);
        }

        protected override void OnWindowDismount()
        {
            _view.EarnClicked -= OnEarnClicked;
            _levelProgress.LevelChanged -= OnLevelChanged;
            _levelProgress.ExperienceAdded -= OnExperienceAdded;
            _manualEarningPower.MoneyPerClickChanged -= OnMoneyPerClickChanged;
        }

        private void OnMoneyPerClickChanged(int oldAmount, int newAmount)
        {
            _view.SetClickPower(newAmount);
        }

        private void OnExperienceAdded(int addedAmount)
        {
            _view.SetExperience(_levelProgress.CurrentExperience, _levelProgress.ExperienceToLevelUp);
        }

        private void OnLevelChanged(int level)
        {
            _view.SetLevel(level);
            _view.SetExperience(_levelProgress.CurrentExperience, _levelProgress.ExperienceToLevelUp);
        }

        private void OnEarnClicked()
        {
            _manualEarner.Earn();
        }
    }
}
