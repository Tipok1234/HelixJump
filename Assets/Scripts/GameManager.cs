using UnityEngine.UI;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public int StartCountHelix => _startCountHelix + _currentLevelIndex;
    public  int NumberOfPassedHelix => _numberOfPassedHelixs;

    public static bool _isGameOver;
    public static bool _isLevelComplited;
    public event Action UpdateScoreAction;
    public event Action StartGameAction;

    [SerializeField] private PlayerBall _playerBall;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _nextLevelPanel;
    [SerializeField] private DataManager _dataManager;

    private  int _currentLevelIndex = 0;
    private  int _numberOfPassedHelixs;

    private int _startCountHelix = 5;

    private void Awake()
    {
        _dataManager.CurrencyUpdatedAction += OnCurrencyUpdated;
        _dataManager.LevelUpdatedAction += OnLevelUpdated;
        _dataManager.DataLodedAction += OnDataLoaded;


        _playerBall.LevelCompletedAction += NextLevelGameUI;
        _playerBall.LevelFailedAction += RestartGameUI;
        _playerBall.FloorPassedAction += UpdateSlider;
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        _numberOfPassedHelixs = 0;
        _isGameOver = false;
        _isLevelComplited = false;
        _levelGenerator.PrepareLevel(_startCountHelix + _currentLevelIndex);
        StartGameAction?.Invoke();
    }
    private void OnCurrencyUpdated(int currency)
    {
        
    }
    private void OnLevelUpdated(int level)
    {
        _currentLevelIndex = level;
    }
    private void OnDataLoaded()
    {
        _currentLevelIndex = _dataManager.CurrentLevelIndex;
    }

    public void RestartOnClick()
    {
        if (_isGameOver)
        {
            ResetSlider();
            _levelGenerator.ClearLevel();
            _levelGenerator.PrepareLevel(_startCountHelix + _currentLevelIndex);
            _playerBall.ResetPosition();
            DestroyRestartUI();
        }
    }

    public void NextLevelOnClick()
    {
        _currentLevelIndex++;
        _dataManager.IncriaseLevel();
        if (_isLevelComplited)
        {
            ResetSlider();
            _levelGenerator.ClearLevel();
            _levelGenerator.PrepareLevel(_startCountHelix + _currentLevelIndex);
            _playerBall.ResetPosition();
            _dataManager.AddCurrency(5);
            DestroyNextLevelGameUI();
        }
    }

    private void UpdateSlider()
    {
        _dataManager.AddCurrency(1);
        _numberOfPassedHelixs++;
        float progress = (float)_numberOfPassedHelixs * 1 / (float)StartCountHelix;
        _dataManager.ProgressLevel.value = progress;
        UpdateScoreAction?.Invoke();
    }

    public void ResetSlider()
    {
        _numberOfPassedHelixs = 0;
        _dataManager.ProgressLevel.value = 0f;
    }
    public void RestartGameUI()
    {
        _isGameOver = true;

        Time.timeScale = 0f;
        _gameOverPanel.SetActive(true);
    }

    public void DestroyRestartUI()
    {
        _isGameOver = false;

        Time.timeScale = 1f;
        _gameOverPanel.SetActive(false);
    }
    public void NextLevelGameUI()
    {
        _isLevelComplited = true;

        Time.timeScale = 0f;
        _nextLevelPanel.SetActive(true);
    }

    public void DestroyNextLevelGameUI()
    {
        _isLevelComplited = false;

        Time.timeScale = 1f;
        _nextLevelPanel.SetActive(false);
    }

    public void SetColor(ColorType colorType)
    {
        _playerBall.SetColorType(colorType);
    }
}
