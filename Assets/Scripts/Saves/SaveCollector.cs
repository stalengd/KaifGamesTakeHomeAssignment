using UnityEngine;
using KaifGames.TestClicker.Saves.Models;

namespace KaifGames.TestClicker.Saves
{
    public sealed class SaveCollector : ISaveCollector
    {
        private readonly ISaveHandler<WalletSaveData> _wallet;
        private readonly ISaveHandler<LevelProgressSaveData> _levelProgress;
        private readonly ISaveHandler<ShopItemsInventorySaveData> _shopItemsInventory;

        public SaveCollector(
            ISaveHandler<WalletSaveData> wallet,
            ISaveHandler<LevelProgressSaveData> levelProgress,
            ISaveHandler<ShopItemsInventorySaveData> shopItemsInventory)
        {
            _wallet = wallet;
            _levelProgress = levelProgress;
            _shopItemsInventory = shopItemsInventory;
        }

        public void NotifyLoad(AppSaveData appData) 
        {
            try
            {
                _wallet.ReadFromSave(appData.Wallet);
                _levelProgress.ReadFromSave(appData.LevelProgress);
                _shopItemsInventory.ReadFromSave(appData.ShopItemsInventory);
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error while initializing services from save.");
                Debug.LogException(ex);
            }
        }

        public void CollectSave(AppSaveData appData)
        {
            _wallet.WriteToSave(appData.Wallet);
            _levelProgress.WriteToSave(appData.LevelProgress);
            _shopItemsInventory.WriteToSave(appData.ShopItemsInventory);
        }
    }
}