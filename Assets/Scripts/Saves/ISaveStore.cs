using System.Threading;
using System.Threading.Tasks;
using KaifGames.TestClicker.Saves.Models;

namespace KaifGames.TestClicker.Saves
{
    public interface ISaveStore
    {
        bool HasSave();
        Task<AppSaveData> ReadAsync(CancellationToken ct);
        Task WriteAsync(AppSaveData data, CancellationToken ct);
    }
}