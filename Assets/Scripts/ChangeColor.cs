using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeColor : MonoBehaviour
{
    public static MeshRenderer _colorMeshRenderer;
    private Color _color2;
   [SerializeField] GameObject[] _cubes;
   [SerializeField] AudioClip _bubleSound;
   [SerializeField] AudioSource _audioSource;
   [SerializeField] ParticleSystem _bubble;
    private float _colorCount = 1;
    private float _colorPercent;
    private Renderer _cubeColor;
    
   private void Start() 
   {
     _colorMeshRenderer = GetComponent<MeshRenderer>();
   }
   private  void Update() 
   {
    ColorPercent();
   }
   private void OnTriggerEnter(Collider other) 
   {
     
     if(other.CompareTag("RedColor"))
     {
        _cubeColor = _cubes[0].GetComponent<Renderer>();
        TakeColor();
         GameManager.Instance._redCount++;
         _audioSource.PlayOneShot(_bubleSound ,1f);
         _bubble.Play(true);
         

     }
      if(other.CompareTag("BlueColor"))
     {
        _cubeColor = _cubes[1].GetComponent<Renderer>();
        TakeColor();
        GameManager.Instance._blueCount++;
        _audioSource.PlayOneShot(_bubleSound ,1f);
       _bubble.Play(true);

       
     }

     if(other.CompareTag("GreenColor"))
     {
        _cubeColor = _cubes[2].GetComponent<Renderer>();
        TakeColor();
        GameManager.Instance._greenCount++;
        _audioSource.PlayOneShot(_bubleSound ,1f);
       _bubble.Play(true);

       
     }
      if(other.CompareTag("YellowColor"))
     {
        _cubeColor = _cubes[3].GetComponent<Renderer>();
        TakeColor();
        GameManager.Instance._yellowCount++; 
        _audioSource.PlayOneShot(_bubleSound ,1f);  
       _bubble.Play(true);
 
     }
     
   }
   private void ColorPercent()
   {
     _colorPercent = 1 / _colorCount;
   }
   private void TakeColor()
   {
       _color2 = _cubeColor.material.color;
      _color2 = _cubeColor.material.color;
       _colorMeshRenderer.material.color = Color.Lerp(_colorMeshRenderer.material.color, _color2 ,_colorPercent);
     
       _colorCount++;  
   }

   
}
