using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameCanvasUI : MonoBehaviour
{
    [SerializeField] private Button _restartGame;
    [SerializeField] private Button _nextLevelGame;
    [SerializeField] private TMP_Text _currentLevelText;
    [SerializeField] private TMP_Text _nextLevelText;

    [SerializeField] private DataManager _dataManager;
    [SerializeField] private GameManager _gameManager;
    private void Awake()
    {
        _dataManager.LevelUpdatedAction += OnLevelUpdated;
        _restartGame.onClick.AddListener(RestartButton);
        _nextLevelGame.onClick.AddListener(NextLevel);
    }
    private void OnLevelUpdated(int level)
    {
        _currentLevelText.text = level.ToString();
        _nextLevelText.text = (level + 1).ToString();
    }

    public void RestartButton()
    {
        _gameManager.RestartOnClick();
    }
    public void NextLevel()
    {
        _gameManager.NextLevelOnClick();
    }
}
