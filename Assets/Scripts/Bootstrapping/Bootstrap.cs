using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace KaifGames.TestClicker.Bootstrapping
{
    public sealed class Bootstrap : IAsyncStartable
    {
        private const int GameSceneIndex = 1;

        public async Task StartAsync(CancellationToken cancellation = default)
        {
            // Loading and stuff here

            // Placeholder so that the compiler does not complain
            await Task.Yield();
            
            LoadGameScene();
        }

        private void LoadGameScene()
        {
            Debug.Log("Loading game scene...");
            SceneManager.LoadScene(GameSceneIndex);
        }
    }
}
