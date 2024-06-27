using System.Collections.Generic;
using Newtonsoft.Json;

namespace KaifGames.TestClicker.Saves.Models
{
    [JsonObject(ItemRequired = Required.Always)]
    public sealed class ShopItemsInventorySaveData
    {
        public List<string> PurchasedItems { get; set; } = new();
    }
}