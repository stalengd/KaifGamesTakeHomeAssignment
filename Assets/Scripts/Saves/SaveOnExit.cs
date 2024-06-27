using UnityEngine;
using VContainer.Unity;

namespace KaifGames.TestClicker.Saves
{
    public sealed class SaveOnExit : IInitializable
    {
        private readonly ISaveDispatcher _saveDispatcher;

        public SaveOnExit(ISaveDispatcher saveDispatcher)
        {
            _saveDispatcher = saveDispatcher;
        }

        public void Initialize()
        {
            Application.focusChanged += OnFocusChanged;
            Application.quitting += OnQuitting;
        }

        private void Deinitialize()
        {
            Application.focusChanged -= OnFocusChanged;
            Application.quitting -= OnQuitting;
        }

        private void OnFocusChanged(bool isInFocus)
        {
            if (!isInFocus)
            {
                _saveDispatcher.SaveAsync(default);
            }
        }

        private void OnQuitting()
        {
            _saveDispatcher.SaveAsync(default);
            Deinitialize();
        }
    }
}