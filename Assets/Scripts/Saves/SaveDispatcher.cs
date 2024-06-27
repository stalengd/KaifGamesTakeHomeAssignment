using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using KaifGames.TestClicker.Saves.Models;

namespace KaifGames.TestClicker.Saves
{
    public sealed class SaveDispatcher : ISaveDispatcher
    {
        private readonly ISaveStore _store;
        private readonly ISaveCollector _saveCollector;
        private AppSaveData _appSaveData;

        public SaveDispatcher(ISaveStore store, ISaveCollector saveCollector)
        {
            _store = store;
            _saveCollector = saveCollector;
        }

        public Task SaveAsync(CancellationToken ct)
        {
            _appSaveData ??= new();
            return SaveFromDataAsync(_appSaveData, ct);
        }

        public async Task LoadAsync(CancellationToken ct)
        {
            var startTime = DateTime.UtcNow;
            if (!_store.HasSave())
            {
                Debug.Log("Save is not found");
                return;
            }
            var data = await _store.ReadAsync(ct);
            if (data == null)
            {
                Debug.LogError("Save is broken");
                return;
            }
            _appSaveData = data;
            _saveCollector.NotifyLoad(_appSaveData);
            Debug.Log($"Save loaded in {(DateTime.UtcNow - startTime).Milliseconds} ms");
        }

        private async Task SaveFromDataAsync(AppSaveData data, CancellationToken ct)
        {
            var startTime = DateTime.UtcNow;
            _saveCollector.CollectSave(data);
            await _store.WriteAsync(data, ct);
            Debug.Log($"Saved in {(DateTime.UtcNow - startTime).Milliseconds} ms");
        }
    }
}