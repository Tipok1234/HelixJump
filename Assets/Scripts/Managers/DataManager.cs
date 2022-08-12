using UnityEngine;
using Assets.Scripts.Enums;
using System;

namespace Assets.Scripts.Managers
{
    public class DataManager : MonoBehaviour
    {
        public int Currency => _currency;
        public int CurrentLevelIndex => _currentLevelIndex;

        public event Action<PlayerProfile> DataLodedAction;
        public event Action<int> LevelUpdatedAction;
        public event Action<int> CurrencyUpdatedAction;

        [SerializeField] private GameManager _gameManager;

        private const string _currentLevelKey = "CurrentLevelIndex";
        private const string _currencyKey = "CurrencyKey";
        private const string _saveKey = "MainSave";

        private int _currency = 0;
        private int _currentLevelIndex = 0;
        private PlayerProfile _playerProfile;
        private void Start()
        {
            LoadData();
        }
        public void LoadData()
        {
            _playerProfile = SaveManager.Load<PlayerProfile>(_saveKey);

            _currentLevelIndex = PlayerPrefs.GetInt(_currentLevelKey, 0);
            _currency = PlayerPrefs.GetInt(_currencyKey, 0);

            DataLodedAction?.Invoke(_playerProfile);
            CurrencyUpdatedAction?.Invoke(_currency);
            LevelUpdatedAction?.Invoke(_currentLevelIndex);
        }
        public bool HasCurrency(int amount)
        {
            if (PlayerPrefs.GetInt(_currencyKey, 0) >= amount)
            {
                return true;
            }
            return false;
        }
        public void SubCurrency(int amount)
        {
            int result = PlayerPrefs.GetInt(_currencyKey, 0) - amount;
            PlayerPrefs.SetInt(_currencyKey, result);
            CurrencyUpdatedAction?.Invoke(result);
        }

        public void AddCurrency(int amount)
        {
            int result = PlayerPrefs.GetInt(_currencyKey, 0) + amount;
            PlayerPrefs.SetInt(_currencyKey, result);
            CurrencyUpdatedAction?.Invoke(result);
        }
        public void IncriaseLevel()
        {
            int newLevel = PlayerPrefs.GetInt(_currentLevelKey, 0) + 1;
            PlayerPrefs.SetInt(_currentLevelKey, newLevel);
            LevelUpdatedAction?.Invoke(newLevel);
        }
        public void OpenColor(ColorType colorType)
        {
            _playerProfile._openedCollors.Add(colorType);
            SaveData();
        }
        private void SaveData()
        {
            SaveManager.Save(_saveKey, _playerProfile);
        }
    }
}
