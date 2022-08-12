using UnityEngine.UI;
using UnityEngine;
using Assets.Scripts.Enums;
using Assets.Scripts.Managers;
using System;

namespace Assets.Scripts.UIManagers
{
    public class ShopMenu : MonoBehaviour
    {
        public int Price => _price;

        [SerializeField] private DataManager _dataManager;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Canvas _shopMenuCanvas;
        [SerializeField] private Button _closeShopMenu;
        [SerializeField] private Button _buyButton;

        [SerializeField] private ShopUIItem[] _shopUIItems;

        private int _price;

        private void Awake()
        {
            _dataManager.DataLodedAction += OnDataLoaded;
            for (int i = 0; i < _shopUIItems.Length; i++)
            {
                _shopUIItems[i].BoughtItemAction += OnItemBought;
                _shopUIItems[i].SelectItemAction += OnItemSelect;
            }
            _closeShopMenu.onClick.AddListener(CloseMenu);
        }
        public void CloseMenu()
        {
            _shopMenuCanvas.enabled = !_shopMenuCanvas.enabled;
        }

        private void OnItemBought(ColorType colorType, int price, Action callBack)
        {
            if (_dataManager.HasCurrency(price))
            {
                _gameManager.SetColor(colorType);
                _dataManager.SubCurrency(price);
                _dataManager.OpenColor(colorType);
                callBack?.Invoke();
            }
            else
            {
                Debug.LogError("NO MONEY!");
            }
        }
        private void OnItemSelect(ColorType colorType)
        {
            _gameManager.SetColor(colorType);
        }
        private void OnDataLoaded(PlayerProfile playerProfile)
        {
            for (int i = 0; i < _shopUIItems.Length; i++)
            {
                for (int j = 0; j < playerProfile._openedCollors.Count; j++)
                {
                    if (_shopUIItems[i].ColorType == playerProfile._openedCollors[j])
                    {
                        _shopUIItems[i].SetOpenState();
                        break;
                    }
                }
            }
        }
    }
}
