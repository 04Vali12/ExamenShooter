using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletsUI;

    [SerializeField]
    private Text _bulletsText;
    [SerializeField]
    
       public Text BulletsText
    {
        get{return _bulletsText;}
    }
    [SerializeField]
    private GameObject _gameOverUI;
    [SerializeField]
    private GameObject _gameWinUI;

    private GameObject _crosshair;
    private void Start()
    {
        ShowBulletsUI(false);
        ShowGameOverUI(false);
        ShowWinUI(false);
        //ShowCrosshairUI(false);
    }


    public void ShowBulletsUI(bool show)
    {
        _bulletsUI.SetActive(show);
    }
    public void ShowGameOverUI(bool show)
    {
        _gameOverUI.SetActive(show);
    }
     public void ShowWinUI(bool show)
    {
        _gameWinUI.SetActive(show);
    }
}
