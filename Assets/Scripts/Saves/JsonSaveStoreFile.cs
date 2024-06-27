using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace KaifGames.TestClicker.Saves
{
    public sealed class JsonSaveStoreFile : IJsonSaveStore
    {
        private readonly string _fullPath;

        public JsonSaveStoreFile(string relativePath)
        {
            _fullPath = Path.Combine(Application.persistentDataPath, relativePath);
        }

        public bool HasSave()
        {
            return File.Exists(_fullPath);
        }

        public async Task<JObject> ReadAsync(CancellationToken ct)
        {
            Debug.Log($"Reading save file from {_fullPath}");
            try
            {
                using var file = File.OpenText(_fullPath);
                using var reader = new JsonTextReader(file);
                var token = await JToken.ReadFromAsync(reader, ct);
                if (token.Type != JTokenType.Object)
                    return null;
                return (JObject)token;
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error while reading or JSON-parsing save file.");
                Debug.LogException(ex);
                return null;
            }
        }

        public Task WriteAsync(JObject data, CancellationToken ct)
        {
            Debug.Log($"Writing save file to {_fullPath}");
            using var file = File.Open(_fullPath, FileMode.Create, FileAccess.Write);
            using var textWriter = new StreamWriter(file);
            using var jsonWriter = new JsonTextWriter(textWriter);
            return data.WriteToAsync(jsonWriter, ct);
        }
    }
}