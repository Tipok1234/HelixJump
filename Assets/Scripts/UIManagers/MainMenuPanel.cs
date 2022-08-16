using UnityEngine.UI;
using UnityEngine;
using Assets.Scripts.Managers;

namespace Assets.Scripts.UIManagers
{
    public class MainMenuPanel : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private GameObject _player;

        [SerializeField] private Canvas _canvasOptionMenu;
        [SerializeField] private Canvas _playGameCanvas;
        [SerializeField] private Canvas _shopCanvas;
        [SerializeField] private Canvas _mainMenuCanvas;

        [SerializeField] private Button _openOptionMenu;
        [SerializeField] private Button _openGameCanvas;
        [SerializeField] private Button _openShopCanvas;

        private void Awake()
        {
            _openOptionMenu.onClick.AddListener(OpenOption);
            _openGameCanvas.onClick.AddListener(PlayGame);
            _openShopCanvas.onClick.AddListener(ShowShop);
        }

        private void OpenOption()
        {
            _canvasOptionMenu.enabled = !_canvasOptionMenu.enabled;
        }
        private void PlayGame()
        {
            _playGameCanvas.enabled = !_playGameCanvas.enabled;
            _player.SetActive(true);
            _mainMenuCanvas.enabled = false;
            _gameManager.StartGame();
        }
        private void ShowShop()
        {
            _shopCanvas.enabled = !_shopCanvas.enabled;
        }
    }
}
