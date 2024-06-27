using UnityEngine;
using TMPro;

namespace KaifGames.TestClicker.UI.WalletDisplay
{
    public sealed class WalletDisplayView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _moneyAmountText;
        
        public void SetMoneyAmount(int amount)
        {
            _moneyAmountText.text = amount.ToString("N0");
        }
    }
}
