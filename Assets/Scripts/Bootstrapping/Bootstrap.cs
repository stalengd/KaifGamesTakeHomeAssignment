using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;
using KaifGames.TestClicker.Saves;

namespace KaifGames.TestClicker.Bootstrapping
{
    public sealed class Bootstrap : IAsyncStartable
    {
        private readonly ISaveDispatcher _saveDispatcher;

        private const int GameSceneIndex = 1;

        public Bootstrap(ISaveDispatcher saveDispatcher)
        {
            _saveDispatcher = saveDispatcher;
        }

        public async Task StartAsync(CancellationToken cancellation = default)
        {
            await _saveDispatcher.LoadAsync(cancellation);
            
            LoadGameScene();
        }

        private void LoadGameScene()
        {
            Debug.Log("Loading game scene...");
            SceneManager.LoadScene(GameSceneIndex);
        }
    }
}
