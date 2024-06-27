using System;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using KaifGames.TestClicker.Saves.Models;
using System.Threading;

namespace KaifGames.TestClicker.Saves
{
    public sealed class SaveStore : ISaveStore
    {
        private readonly IJsonSaveStore _rawStore;
        private readonly JsonSerializer _serializer;

        private const int CurrentSaveFormatVersion = 0;


        public SaveStore(IJsonSaveStore rawStore)
        {
            _rawStore = rawStore;
            _serializer = JsonSerializer.Create(new JsonSerializerSettings()
            {
                
            });
        }

        public bool HasSave()
        {
            return _rawStore.HasSave();
        }

        public async Task<AppSaveData> ReadAsync(CancellationToken ct)
        {
            var json = await _rawStore.ReadAsync(ct);
            if (json == null)
            {
                return null;
            }
            // Here we can migrate if needed,
            // for now old file schema will cause load fault
            try
            {
                return json.ToObject<AppSaveData>(_serializer);
            }
            catch (Exception ex)
            {
                Debug.LogError("Error while mapping save data to schema.");
                Debug.LogException(ex);
                return null;
            }
        }

        public Task WriteAsync(AppSaveData data, CancellationToken ct)
        {
            WriteSaveHeader(data);
            var json = JObject.FromObject(data);
            return _rawStore.WriteAsync(json, ct);
        }

        private void WriteSaveHeader(AppSaveData data)
        {
            data.SaveFormatVersion = CurrentSaveFormatVersion;
            data.AppVersion = Application.version;
            data.SaveTimestamp = DateTime.UtcNow;
        }
    }
}