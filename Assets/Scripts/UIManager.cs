//using UnityEngine;
//using TMPro;


//public class UIManager : MonoBehaviour
//{
//    [SerializeField] private GameManager _gameManager;
//    [SerializeField] private TMP_Text _cashText;

//    private void Awake()
//    {
//        _gameManager.UpdateScoreAction += UpCash;
//        _gameManager.StartGameAction += OnGameStarted;
//    }
//    public void UpCash()
//    {
//        _cashText.text = _gameManager.ScoreCash.ToString();
//    }
//    public void OnGameStarted()
//    {
//        UpCash();
//    }
//}
