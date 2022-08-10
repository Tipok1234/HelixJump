using UnityEngine.UI;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    public static OptionMenu _optionMenu;

    [SerializeField] private Canvas _canvasOptionMenu;
   // [SerializeField] private Canvas _canvasMainMenu;
    [SerializeField] private Button _openOptionMenu;
    [SerializeField] private Button _backOptionMenu;
   // [SerializeField] private Button _openMainMenu;

    private void Awake()
    {
        _openOptionMenu.onClick.AddListener(OpenOptionMenu);
        _backOptionMenu.onClick.AddListener(OpenOptionMenu);
     //   _openMainMenu.onClick.AddListener(OpenMainMenu);
    }

    private void OpenOptionMenu()
    {
        _canvasOptionMenu.enabled = !_canvasOptionMenu.enabled;
    }
    //private void OpenMainMenu()
    //{
    //    _canvasMainMenu.enabled = !_canvasMainMenu.enabled;
    //    _canvasOptionMenu.enabled = false;
    //}
    public void Sound()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
