using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSplash : MonoBehaviour
{
    [SerializeField] ParticleSystem _lastSplash;
    [SerializeField] GameObject _colorObject;
    [SerializeField] GameObject _waveObject;
     
    
    private void OnEnable() 
    {
        GameManager.Instance.OnLevelFinish += Splash;
    }
    private void Splash()
    {
        
     _lastSplash.Play();
     _colorObject.SetActive(false);
     _waveObject.SetActive(false);
      
    }
}



