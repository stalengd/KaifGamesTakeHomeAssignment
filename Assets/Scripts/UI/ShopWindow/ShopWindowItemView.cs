using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace KaifGames.TestClicker.UI.ShopWindow
{
    public sealed class ShopWindowItemView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private Image _iconImage;
        [SerializeField] private GameObject _purchasedIndicator;

        public event System.Action Clicked;

        private void Awake()
        {
            _button.onClick.AddListener(OnClicked);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void SetName(string name)
        {
            _nameText.text = name;
        }

        public void SetIcon(Sprite icon)
        {
            _iconImage.sprite = icon;
        }

        public void SetPurchased(bool isPurchased)
        {
            _purchasedIndicator.SetActive(isPurchased);
        }

        private void OnClicked()
        {
            Clicked?.Invoke();
        }
    }
}
