using KaifGames.TestClicker.Saves.Models;

namespace KaifGames.TestClicker.Saves
{
    public interface ISaveCollector
    {
        void NotifyLoad(AppSaveData appData); 
        void CollectSave(AppSaveData appData);
    }
}