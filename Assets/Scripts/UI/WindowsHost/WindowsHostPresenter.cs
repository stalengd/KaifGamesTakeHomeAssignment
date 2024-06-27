using System;
using System.Collections.Generic;
using KaifGames.TestClicker.UI.WindowToggle;

namespace KaifGames.TestClicker.UI.WindowsHost
{
    public sealed class WindowsHostPresenter : IDisposable
    {
        private readonly WindowsHostView _view;
        private readonly List<WindowTogglePresenter> _windowToggles = new();
        private WindowsHostModel _model;

        public WindowsHostPresenter(WindowsHostView view)
        {
            _view = view;
        }

        public void Render(WindowsHostModel model)
        {
            _model = model;
            for (int i = 0; i < _model.Windows.Count; i++)
            {
                var toggle = new WindowTogglePresenter(_view.GetWindowToggleView(i));
                toggle.Render(new WindowToggleModel(_model.Windows[i]));
                _windowToggles.Add(toggle);
            }
        }

        public void Dispose()
        {
            foreach (var toggle in _windowToggles)
            {
                toggle.Hide();
            }
            _windowToggles.Clear();
        }
    }
}
