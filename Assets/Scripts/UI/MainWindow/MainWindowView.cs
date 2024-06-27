using DG.Tweening;
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

        [Header("Click popup")]
        [SerializeField] private GameObject _clickPopupPrefab;
        [SerializeField] private Transform _clickPopupsHolder;
        [SerializeField] private float _clickPopupLifetime = 1f;

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

        public void CreateClickPopup(int clickPower, Vector2 screenPosition)
        {
            var popup = Instantiate(_clickPopupPrefab, _clickPopupsHolder);
            popup.transform.position = screenPosition;
            popup.transform.DOMoveY(screenPosition.y + 200f, _clickPopupLifetime);

            var text = popup.GetComponent<TMP_Text>();
            text.text = $"+{clickPower}";
            text.DOFade(0f, _clickPopupLifetime);

            Destroy(popup, _clickPopupLifetime + 0.1f);
        }

        private void OnEarnClicked()
        {
            EarnClicked?.Invoke();
        }
    }
}
