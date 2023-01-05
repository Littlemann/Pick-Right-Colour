using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageColor : MonoBehaviour
{
    private Renderer _renderer;

    
   private void Start() 
   {
     _renderer = GetComponent<Renderer>();

   }
   private void Update()
   {
    PaintWall();
   }
   
   private void PaintWall()
   {
    if(GameManager.Instance._leveldone)
    {
      
      _renderer.material.color = ChangeColor._colorMeshRenderer.material.color; 
    }
    
   }
}
