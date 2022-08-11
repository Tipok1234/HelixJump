using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    public int Price => _price;

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Canvas _shopMenuCanvas;
    [SerializeField] private Button _closeShopMenu;
    [SerializeField] private Button _buyButton;

    [SerializeField] private TMP_Text _cash;
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
        if(_gameManager.ScoreCashIndex >= price)
        {
            _gameManager.SetColor(colorType);
            _gameManager.AddCash(price);
            _cash.text = _gameManager.ScoreCashIndex.ToString();
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
