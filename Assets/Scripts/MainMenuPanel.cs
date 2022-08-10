using UnityEngine.UI;
using UnityEngine;

public class MainMenuPanel : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
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

    public void OpenOption()
    {
        _canvasOptionMenu.enabled = !_canvasOptionMenu.enabled;
    }
    public void PlayGame()
    {
        _playGameCanvas.enabled = !_playGameCanvas.enabled;
        _mainMenuCanvas.enabled = false;
        _gameManager.StartGame();
    }
    public void ShowShop()
    {
        _shopCanvas.enabled = !_shopCanvas.enabled;
    }
}
