using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeColor : MonoBehaviour
{
   private Renderer _renderer;

   private void Start() 
   {
     _renderer = GetComponent<Renderer>();
   }
   private void Update()
   {
      _renderer.material.color = ChangeColor._colorMeshRenderer.material.color; 
   }
}
