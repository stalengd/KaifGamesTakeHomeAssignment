using System.Threading;
using System.Threading.Tasks;

namespace KaifGames.TestClicker.Saves
{
    public interface ISaveDispatcher
    {
        Task SaveAsync(CancellationToken ct);
        Task LoadAsync(CancellationToken ct);
    }
}