using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts.UIManagers
{
    public class OptionMenu : MonoBehaviour
    {
        public static OptionMenu _optionMenu;

        [SerializeField] private Canvas _canvasOptionMenu;
        [SerializeField] private Canvas _canvasShopMenu;
        [SerializeField] private Button _openOptionMenu;
        [SerializeField] private Button _backOptionMenu;
        [SerializeField] private Button _openShopButton;

        private void Awake()
        {
            _openOptionMenu.onClick.AddListener(OpenOptionMenu);
            _backOptionMenu.onClick.AddListener(OpenOptionMenu);
            _openShopButton.onClick.AddListener(OpenShopMenu);
        }

        private void OpenOptionMenu()
        {
            _canvasOptionMenu.enabled = !_canvasOptionMenu.enabled;
        }
        private void OpenShopMenu()
        {
            _canvasShopMenu.enabled = !_canvasShopMenu.enabled;
        }
        private void Sound()
        {
            AudioListener.pause = !AudioListener.pause;
        }
    }
}
