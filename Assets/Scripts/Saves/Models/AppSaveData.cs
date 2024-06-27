using System;
using Newtonsoft.Json;

namespace KaifGames.TestClicker.Saves.Models
{
    [JsonObject(ItemRequired = Required.Always)]
    public sealed class AppSaveData
    {
        public int SaveFormatVersion { get; set; }
        public string AppVersion { get; set; }
        public DateTime SaveTimestamp { get; set; }

        public WalletSaveData Wallet { get; } = new();
        public LevelProgressSaveData LevelProgress { get; } = new();
        public ShopItemsInventorySaveData ShopItemsInventory { get; } = new();
    }
}