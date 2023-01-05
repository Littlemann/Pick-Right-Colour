using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   [SerializeField]  AudioClip _splash;
   [SerializeField]  AudioClip _deathSound;
   [SerializeField] AudioSource _audioSource;
   
   private void OnEnable() 
   {
     GameManager.Instance.OnLevelFinish += PlaySplashSound;
      GameManager.Instance.OnFail += PlayDeathSound;
   }
   private void PlaySplashSound()
   {
        _audioSource.PlayOneShot(_splash , 0.4f);
   }
   private void PlayDeathSound()
   {
      _audioSource.PlayOneShot(_deathSound , 0.6f);
   }



}
