using UnityEngine.UI;
using UnityEngine;
using System;

public class ShopUIItem : MonoBehaviour
{
    public ColorType ColorType => _colorType;

    public event Action<ColorType,int, Action> BoughtItemAction;
    public event Action<ColorType> SelectItemAction;

    [SerializeField] private int _price;

    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _selectButton;
    [SerializeField] private ColorType _colorType;
    private void Awake()
    {
        _buyButton.onClick.AddListener(BoughtItem);
        _selectButton.onClick.AddListener(SelectItem);
    }

    private void BoughtItem()
    {
        BoughtItemAction?.Invoke(_colorType, _price,BuyColorCallBack);
    }

    private void SelectItem()
    {
        SelectItemAction?.Invoke(_colorType);
    }
    private void BuyColorCallBack()
    {
        _buyButton.gameObject.SetActive(false);
        _selectButton.gameObject.SetActive(true);
    }
}