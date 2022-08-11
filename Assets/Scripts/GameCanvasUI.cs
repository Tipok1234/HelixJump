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
        _restartGame.onClick.AddListener(_gameManager.RestartOnClick);
        _nextLevelGame.onClick.AddListener(_gameManager.NextLevelOnClick);
    }
    private void OnLevelUpdated(int level)
    {
        _currentLevelText.text = level.ToString();
        _nextLevelText.text = (level + 1).ToString();
    }
}
