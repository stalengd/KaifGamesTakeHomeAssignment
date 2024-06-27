using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace KaifGames.TestClicker.Saves
{
    public interface IJsonSaveStore
    {
        bool HasSave();
        Task<JObject> ReadAsync(CancellationToken ct);
        Task WriteAsync(JObject data, CancellationToken ct);
    }
}