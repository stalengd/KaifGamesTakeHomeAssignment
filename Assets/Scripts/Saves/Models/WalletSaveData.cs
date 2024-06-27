using Newtonsoft.Json;

namespace KaifGames.TestClicker.Saves.Models
{
    [JsonObject(ItemRequired = Required.Always)]
    public sealed class WalletSaveData
    {
        public int MoneyAmount { get; set; } 
    }
}