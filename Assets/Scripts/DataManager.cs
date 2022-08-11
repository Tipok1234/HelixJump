using UnityEngine.UI;
using UnityEngine;
using System;

public class DataManager : MonoBehaviour
{
    public int Currency => _currency;
    public int CurrentLevelIndex => _currentLevelIndex;

    public Slider ProgressLevel => _progressLevelSlider;

    public event Action DataLodedAction;
    public event Action<int> LevelUpdatedAction;
    public event Action<int> CurrencyUpdatedAction;

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Slider _progressLevelSlider;


    private const string _currentLevelKey = "CurrentLevelIndex";
    private const string _currencyKey = "CurrencyKey";

    private int _currency = 0;
    private int _currentLevelIndex = 0;

    private void Start()
    {
        LoadData();
    }
    public void LoadData()
    {
        _currentLevelIndex = PlayerPrefs.GetInt(_currentLevelKey, 0);
        _currency = PlayerPrefs.GetInt(_currencyKey, 0);

        DataLodedAction?.Invoke();
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
        int newLevel = PlayerPrefs.GetInt(_currentLevelKey,0)+1;
        PlayerPrefs.SetInt(_currentLevelKey, newLevel);
        LevelUpdatedAction?.Invoke(newLevel);
    }
    public void SaveData()
    {

    }
}
