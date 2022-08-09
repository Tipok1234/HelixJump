using UnityEngine.UI;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    public static OptionMenu _optionMenu;

    [SerializeField] private Canvas _canvasOptionMenu;
    [SerializeField] private Button _openOptionMenu;
    [SerializeField] private Button _backOptionMenu;

    private void Awake()
    {
        _openOptionMenu.onClick.AddListener(OpenOptionMenu);
        _backOptionMenu.onClick.AddListener(OpenOptionMenu);
    }

    private void OpenOptionMenu()
    {
        _canvasOptionMenu.enabled = !_canvasOptionMenu.enabled;
    }

    public void Sound()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
