using System.Collections.Generic;
using KaifGames.TestClicker.UI.Window;

namespace KaifGames.TestClicker.UI.WindowsHost
{
    public sealed class WindowsHostModel
    {
        public IReadOnlyList<WindowModel> Windows => _windows;
        private List<WindowModel> _windows = new();
        private WindowModel _activeWindow = null;

        public void AddWindow(WindowModel window)
        {
            window.Host = this;
            _windows.Add(window);
        }

        public void RemoveWindow(WindowModel window)
        {
            window.Host = null;
            _windows.Remove(window);
        }

        public void ActivateWindow(WindowModel window)
        {
            if (_activeWindow == window)
            {
                return;
            }
            _activeWindow?.SetDeactivated();
            _activeWindow = window;
            _activeWindow?.SetActivated();
        }
    }
}
