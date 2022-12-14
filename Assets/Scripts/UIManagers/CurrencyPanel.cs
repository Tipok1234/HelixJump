using UnityEngine;
using Assets.Scripts.Managers;
using TMPro;

namespace Assets.Scripts.UIManagers
{
    public class CurrencyPanel : MonoBehaviour
    {
        [SerializeField] private DataManager _dataManager;
        [SerializeField] private TMP_Text _cashText;

        private void Awake()
        {
            _dataManager.CurrencyUpdatedAction += OnCurrencyUpdated;
        }
        public void OnCurrencyUpdated(int currency)
        {
            _cashText.text = currency.ToString();
        }
    }
}
