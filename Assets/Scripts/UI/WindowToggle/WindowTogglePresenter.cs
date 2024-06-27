namespace KaifGames.TestClicker.UI.WindowToggle
{
    public sealed class WindowTogglePresenter
    {
        private WindowToggleModel _model;
        private readonly WindowToggleView _view;

        public WindowTogglePresenter(WindowToggleView view)
        {
            _view = view;
        }

        public void Render(WindowToggleModel model)
        {
            _model = model;
            _view.SetSelected(model.Window.IsActive);
            _view.Selected += OnSelected;
            _model.Window.Activated += OnWindowActivated;
            _model.Window.Deactivated += OnWindowDeactivated;
        }

        public void Hide()
        {
            if (_view != null)
            {
                _view.SetSelected(false);
            }
            _view.Selected -= OnSelected;
            _model.Window.Activated -= OnWindowActivated;
            _model.Window.Deactivated -= OnWindowDeactivated;
        }

        private void OnSelected()
        {
            _model.Window.Activate();
        }

        private void OnWindowActivated()
        {
            _view.SetSelected(true);
        }

        private void OnWindowDeactivated()
        {
            _view.SetSelected(false);
        }
    }
}
