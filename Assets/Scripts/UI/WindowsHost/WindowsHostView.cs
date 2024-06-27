using UnityEngine;
using KaifGames.TestClicker.UI.WindowToggle;

namespace KaifGames.TestClicker.UI.WindowsHost
{
    public sealed class WindowsHostView : MonoBehaviour
    {
        [SerializeField] private WindowToggleView[] _toggles;
        
        public WindowToggleView GetWindowToggleView(int index)
        {
            return _toggles[index];
        }
    }
}
