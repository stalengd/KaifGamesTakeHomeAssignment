using Newtonsoft.Json;

namespace KaifGames.TestClicker.Saves.Models
{
    [JsonObject(ItemRequired = Required.Always)]
    public sealed class LevelProgressSaveData
    {
        public int Level { get; set; } 
        public int Experience { get; set; } 
    }
}