using UnityEngine.UI;
using Assets.Scripts.Enums;
using UnityEngine;
using System;
using TMPro;

namespace Assets.Scripts.UIManagers
{
    public class ShopUIItem : MonoBehaviour
    {
        public ColorType ColorType => _colorType;

        public event Action<ColorType, int, Action> BoughtItemAction;
        public event Action<ColorType> SelectItemAction;

        [SerializeField] private int _price;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _selectButton;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private Image _imageUIItem;
        [SerializeField] private ColorType _colorType;

        private void Awake()
        {
            _buyButton.onClick.AddListener(BoughtItem);
            _selectButton.onClick.AddListener(SelectItem);
            _priceText.text = _price.ToString();
        }

        private void BoughtItem()
        {
            BoughtItemAction?.Invoke(_colorType, _price, BuyColorCallBack);
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

        public void SetOpenState()
        {
            BuyColorCallBack();
        }
    }
}