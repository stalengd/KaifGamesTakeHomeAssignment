using UnityEngine;
using UnityEngine.UI;

namespace KaifGames.TestClicker.UI.WindowToggle
{
    public sealed class WindowToggleView : MonoBehaviour
    {
        [SerializeField] private Graphic[] _tintTargets;
        [SerializeField] private Color _normalColor;
        [SerializeField] private Color _selectedColor;
        [SerializeField] private Button _button;

        public bool IsSelected { get; private set; }

        public event System.Action Selected;

        private void Awake()
        {
            _button.onClick.AddListener(OnClicked);
        }

        public void SetSelected(bool isSelected)
        {
            IsSelected = isSelected;
            foreach (Graphic tintTarget in _tintTargets)
            {
                tintTarget.color = isSelected ? _selectedColor : _normalColor;
            }
        }

        private void OnClicked()
        {
            Selected?.Invoke();
        }
    }
}
