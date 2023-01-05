using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
  [SerializeField] private Image[] _redColors ;
  [SerializeField] private Image[] _blueColors ;
  [SerializeField] private Image[] _greenColors ;
  [SerializeField] private Image[] _yellowColors ;
  [SerializeField] private GameObject _clickToStartText;
  [SerializeField] private GameObject _clickToStartButton;
  [SerializeField] private TextMeshProUGUI _accurityText;
  [SerializeField] private TextMeshProUGUI _percentText;
  
  
  private void OnEnable() 
  {
    GameManager.Instance.OnLevelFinish += EnableTexts;
  }
  private void Update() 
  {
    DisableColors();
  
  }
  private void DisableColors()
  {
 
    if(GameManager.Instance._redCount > 0 && _redColors.Length >= GameManager.Instance._redCount )
    {
        _redColors[GameManager.Instance._redCount -1].gameObject.SetActive(false);
    }
    if(GameManager.Instance._blueCount >0 && _blueColors.Length >= GameManager.Instance._blueCount  )
    {
        _blueColors[GameManager.Instance._blueCount -1].gameObject.SetActive(false);
    }
     if(GameManager.Instance._greenCount >0 && _greenColors.Length >= GameManager.Instance._greenCount  )
    {
        _greenColors[GameManager.Instance._greenCount -1].gameObject.SetActive(false);
    }
     if(GameManager.Instance._yellowCount >0 && _yellowColors.Length >= GameManager.Instance._yellowCount )
    {
        _yellowColors[GameManager.Instance._yellowCount -1].gameObject.SetActive(false);
    }

  
  }
   private void EnableTexts()
    {
            _accurityText.gameObject.SetActive(true);
            _percentText.gameObject.SetActive(true);
            _accurityText.text = GameManager.Instance._accColor.ToString();
    }
    public void StartToClick()
    {
      GameManager.Instance._canMove = true;
      _clickToStartText.SetActive(false);
      _clickToStartButton.SetActive(false);
    }
   

}
