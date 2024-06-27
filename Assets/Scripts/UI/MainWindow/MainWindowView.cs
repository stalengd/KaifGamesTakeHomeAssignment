using UnityEngine;
using UnityEngine.UI;
using TMPro;
using KaifGames.TestClicker.UI.Window;

namespace KaifGames.TestClicker.UI.MainWindow
{
    public sealed class MainWindowView : WindowView
    {
        [SerializeField] private Button _earnButton;
        [SerializeField] private TMP_Text _clickPowerText;
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private Image _levelBarFill;

        public event System.Action EarnClicked;

        private void Awake()
        {
            _earnButton.onClick.AddListener(OnEarnClicked);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void SetExperience(int experience, int maxExperience)
        {
            _levelBarFill.fillAmount = (float)experience / maxExperience;
        }

        public void SetLevel(int level)
        {
            _levelText.text = $"Level {level + 1}";
        }

        public void SetClickPower(int clickPower)
        {
            _clickPowerText.text = $"{clickPower}/per click";
        } 

        private void OnEarnClicked()
        {
            EarnClicked?.Invoke();
        }
    }
}
