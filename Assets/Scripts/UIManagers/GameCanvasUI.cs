using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Assets.Scripts.Managers;

namespace Assets.Scripts.UIManagers
{
    public class GameCanvasUI : MonoBehaviour
    {
        public Slider ProgressLevel => _progressLevelSlider;

        [SerializeField] private Button _restartGame;
        [SerializeField] private Button _nextLevelGame;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private TMP_Text _currentLevelText;
        [SerializeField] private TMP_Text _nextLevelText;
        [SerializeField] private Canvas _optionCanvas;

        [SerializeField] private Slider _progressLevelSlider;

        [SerializeField] private DataManager _dataManager;
        [SerializeField] private GameManager _gameManager;
        private void Awake()
        {
            _dataManager.LevelUpdatedAction += OnLevelUpdated;
            _restartGame.onClick.AddListener(RestartButton);
            _nextLevelGame.onClick.AddListener(NextLevel);
            _pauseButton.onClick.AddListener(Pause);
            _resumeButton.onClick.AddListener(Resume);
        }
        private void OnLevelUpdated(int level)
        {
            _currentLevelText.text = level.ToString();
            _nextLevelText.text = (level + 1).ToString();
        }

        private void RestartButton()
        {
            _gameManager.RestartOnClick();
        }
        private void NextLevel()
        {
            _gameManager.NextLevelOnClick();
        }
        private void Resume()
        {
            _optionCanvas.enabled = false;
            Time.timeScale = 1f;
        }

        private void Pause()
        {
            _optionCanvas.enabled = true;
            Time.timeScale = 0f;
        }
    }
}
