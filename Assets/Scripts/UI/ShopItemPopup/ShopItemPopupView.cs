using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace KaifGames.TestClicker.UI.ShopItemPopup
{
    public sealed class ShopItemPopupView : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _buyButton;
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _costText;
        [SerializeField] private TMP_Text _effectText;
        [SerializeField] private Image _iconImage;

        public event System.Action ExitPressed;
        public event System.Action BuyPressed;

        private void Awake()
        {
            _exitButton.onClick.AddListener(OnExitPressed);
            _buyButton.onClick.AddListener(OnBuyPressed);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void SetName(string name)
        {
            _nameText.text = name;
        }

        public void SetCost(int amount)
        {
            _costText.text = amount.ToString();
        }

        public void SetClickPowerGain(int amount)
        {
            _effectText.text = $"+{amount} per click";
        }

        public void SetIcon(Sprite icon)
        {
            _iconImage.sprite = icon;
        }

        public void SetPurchasable(bool isPurchasable)
        {
            _buyButton.interactable = isPurchasable;
        }

        private void OnExitPressed()
        {
            ExitPressed?.Invoke();
        }

        private void OnBuyPressed()
        {
            BuyPressed?.Invoke();
        }
    }
}
