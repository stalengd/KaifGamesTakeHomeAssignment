using UnityEngine;

namespace KaifGames.TestClicker.Shop
{
    public interface IShopItem
    {
        string Id { get; }
        string Name { get; }
        Sprite Icon { get; }
        int Cost { get; }
        int ClickPowerGain { get; }
    }
}