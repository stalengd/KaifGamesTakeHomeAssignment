using KaifGames.TestClicker.UI.WindowsHost;

namespace KaifGames.TestClicker.UI.Window
{
    public class WindowModel
    {
        public WindowsHostModel Host { get; set; }
        public bool IsActive { get; private set; }

        public event System.Action Activated;
        public event System.Action Deactivated;

        public void Activate()
        {
            Host.ActivateWindow(this);
        }

        public void SetActivated()
        {
            IsActive = true;
            Activated?.Invoke();
        }

        public void SetDeactivated()
        {
            IsActive = false;
            Deactivated?.Invoke();
        }
    }
}
