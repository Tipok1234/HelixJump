using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
  //  public static GameManager Instance => _instance;
    public int StartCountHelix => _startCountHelix + _currentLevelIndex;
    public  int NumberOfPassedHelix => _numberOfPassedHelixs;
    public int ScoreCashIndex => _scoreCash;

    public static bool _isGameOver;
    public static bool _isLevelComplited;
    public event Action UpdateScoreAction;
    public event Action StartGameAction;

    [SerializeField] private PlayerBall _playerBall;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _nextLevelPanel;
    [SerializeField] private Button _restartGame;
    [SerializeField] private Button _nextLevelGame;
    [SerializeField] private TMP_Text _currentLevelText;
    [SerializeField] private TMP_Text _nextLevelText;
    [SerializeField] private Slider _progressLevelSlider;

   // private static GameManager _instance;

    public  int _currentLevelIndex = 0;
    private  int _numberOfPassedHelixs;

    private int _startCountHelix = 5;
    private int _scoreCash;

    //private Vector3 posBall = new Vector3(0, 9.5f, -1.95f);

    private void Awake()
    {
        _currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
        _scoreCash = PlayerPrefs.GetInt("ScoreCash", 1);

        _playerBall.LevelCompletedAction += NextLevelGameUI;
        _playerBall.LevelFailedAction += RestartGameUI;
        _playerBall.FloorPassedAction += UpdateSlider;

        _restartGame.onClick.AddListener(RestartOnClick);
        _nextLevelGame.onClick.AddListener(NextLevelOnClick);
        _levelGenerator.PrepareLevel(_startCountHelix + _currentLevelIndex);
    }
    public void Start()
    {
        Time.timeScale = 1f;
        _numberOfPassedHelixs = 0;
        _isGameOver = false;
        _isLevelComplited = false;
        StartGameAction?.Invoke();
    }

    private void Update()
    {
        _currentLevelText.text = _currentLevelIndex.ToString();
        _nextLevelText.text = (_currentLevelIndex + 1).ToString();
    }
    private void RestartOnClick()
    {
        if (_isGameOver)
        {
            _levelGenerator.ClearLevel();
        }
    }

    private void NextLevelOnClick()
    {
        _currentLevelIndex++;
        PlayerPrefs.SetInt("CurrentLevelIndex", _currentLevelIndex);
        if (_isLevelComplited)
        {
            _levelGenerator.ClearLevel();

            //SceneManager.LoadScene("Level1");
            PlayerPrefs.SetInt("ScoreCash", _scoreCash + 5);
        }
    }

    private void UpdateSlider()
    {
        _scoreCash++;
       // PlayerPrefs.SetInt("ScoreCash", _scoreCash);
        _numberOfPassedHelixs++;
        float progress = (float)_numberOfPassedHelixs * 1 / (float)StartCountHelix;
        _progressLevelSlider.value = progress;
        UpdateScoreAction?.Invoke();

    }
    public void RestartGameUI()
    {
        _isGameOver = true;

        Time.timeScale = 0f;
        _gameOverPanel.SetActive(true);
    }
    public void NextLevelGameUI()
    {

        _isLevelComplited = true;

        Time.timeScale = 0f;
        _nextLevelPanel.SetActive(true);
    }
}
