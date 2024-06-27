using UnityEngine;

namespace KaifGames.TestClicker.Shop
{
    [CreateAssetMenu(menuName = "Data/Shop/Item")]
    public sealed class ShopItem : ScriptableObject, IShopItem
    {
        // Using asset name as an Id have some downsides, but I believe it is nice developer experience
        public string Id => name;

        public string Name => _name;
        [SerializeField] private string _name;

        public Sprite Icon => _icon;
        [SerializeField] private Sprite _icon;

        public int Cost => _cost;
        [SerializeField] private int _cost = 1;

        public int ClickPowerGain => _clickPowerGain;
        [SerializeField] private int _clickPowerGain = 1;
    }
}