using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using KaifGames.TestClicker.UI.Window;
using KaifGames.TestClicker.UI.Elements;

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

        private ObjectPool _clickPopupsPool;

        private void Awake()
        {
            _earnButton.onClick.AddListener(OnEarnClicked);
            _clickPopupsPool = new(_clickPopupPrefab);
        }

        private void OnDisable()
        {
            _clickPopupsPool.SoftDestroyActive();
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
            var popup = _clickPopupsPool.Instantiate(_clickPopupsHolder);
            popup.transform.position = screenPosition;
            popup.transform.DOMoveY(screenPosition.y + 200f, _clickPopupLifetime);

            var text = popup.GetComponent<TMP_Text>();
            text.text = $"+{clickPower}";
            text.alpha = 1f;
            text.DOFade(0f, _clickPopupLifetime);

            StartCoroutine(DestroyClickPopupCor(popup, _clickPopupLifetime + 0.1f));
        }

        private void OnEarnClicked()
        {
            EarnClicked?.Invoke();
        }

        private IEnumerator DestroyClickPopupCor(GameObject clickPopup, float delay)
        {
            yield return new WaitForSeconds(delay);
            _clickPopupsPool.SoftDestroy(clickPopup);
        }
    }
}
