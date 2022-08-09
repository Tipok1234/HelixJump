using UnityEngine.UI;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private Canvas _shopMenuCanvas;
    [SerializeField] private Button _closeShopMenu;
    [SerializeField] private Button _buyButton;

  //  [SerializeField] private Material _myMaterial;
    //[SerializeField] private PlayerBall _playerBall;
    
    private void Awake()
    {
        _closeShopMenu.onClick.AddListener(CloseMenu);
      //  _buyButton.onClick.AddListener(ShopBall);
    }

    public void CloseMenu()
    {
        _shopMenuCanvas.enabled = !_shopMenuCanvas.enabled;
    }

    //public void ShopBall()
    //{
    //    if(GameManager.Instance.ScoreCashIndex > 100)
    //    {
    //        _myMaterial.color = Color.green;
    //    }
    //}
}
