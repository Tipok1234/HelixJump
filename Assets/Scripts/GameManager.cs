using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool _isGameOver;
    public static bool _isLevelComplited;

    [SerializeField] private PlayerBall _playerBall;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _nextLevelPanel;
    [SerializeField] private Button _restartGame;
    [SerializeField] private Button _nextLevelGame;
    [SerializeField] private TMP_Text _currentLevelText;
    [SerializeField] private TMP_Text _nextLevelText;
    [SerializeField] private Slider _progressLevelSlider;

    public static int _currentLevelIndex = 0;
    public static int _numberOfPassedHelixs;

    //private Vector3 posBall = new Vector3(0, 9.5f, -1.95f);

    private void Awake()
    {
        _currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);

        _playerBall.LevelCompletedAction += NextLevelGameUI;
        _playerBall.LevelFailedAction += RestartGameUI;

        _restartGame.onClick.AddListener(RestartOnClick);
        _nextLevelGame.onClick.AddListener(NextLevelOnClick);
    }
    private void Start()
    {

        Time.timeScale = 1f;
        _numberOfPassedHelixs = 0;
        _isGameOver = false;
        _isLevelComplited = false;
    }

    private void Update()
    {
        _currentLevelText.text = _currentLevelIndex.ToString();
        _nextLevelText.text = (_currentLevelIndex + 1).ToString();

        int progress = _numberOfPassedHelixs * 100 / FindObjectOfType<LevelGenerator>().NumberHelix;
        _progressLevelSlider.value = progress;
    }
    private void RestartOnClick()
    {
        if (_isGameOver)
        {
                SceneManager.LoadScene("Level1");
            
        }
    }

    private void NextLevelOnClick()
    {
        _currentLevelIndex++;
        PlayerPrefs.SetInt("CurrentLevelIndex", _currentLevelIndex);
        if (_isLevelComplited)
        {
            SceneManager.LoadScene("Level1");
        }
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
