using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCount : MonoBehaviour
{
    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;
    
  

    
    private void Start() 
    {
        if(GameManager.Instance._accColor >= 88)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
            if(GameManager.Instance._accColor < 88 && GameManager.Instance._accColor > 33 )
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }
        if(GameManager.Instance._accColor < 33 )
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }
    }

}
