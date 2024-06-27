namespace KaifGames.TestClicker.UI.Window
{
    public abstract class WindowPresenter : System.IDisposable
    {
        public WindowModel WindowModel { get; private set; }

        protected WindowPresenter(WindowModel windowModel)
        {
            WindowModel = windowModel;
            windowModel.Activated += OnActivatedInternal;
            windowModel.Deactivated += OnDeactivatedInternal;
        }

        public virtual void Dispose()
        {
            WindowModel.Activated -= OnActivatedInternal;
            WindowModel.Deactivated -= OnDeactivatedInternal;
            if (WindowModel.IsActive)
            {
                OnWindowDismount();
            }
        }

        protected virtual void OnWindowActivated()
        {
            
        }

        protected virtual void OnWindowDeactivated()
        {

        }

        protected virtual void OnWindowDismount()
        {

        }

        private void OnActivatedInternal()
        {
            OnWindowActivated();
        }

        private void OnDeactivatedInternal()
        {
            OnWindowDeactivated();
            OnWindowDismount();
        }
    }
}
