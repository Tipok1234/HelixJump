using UnityEngine.UI;
using UnityEngine;
using System;

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
        if(_dataManager.HasCurrency(price))
        {
            _gameManager.SetColor(colorType);
            _dataManager.SubCurrency(price);
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
}
