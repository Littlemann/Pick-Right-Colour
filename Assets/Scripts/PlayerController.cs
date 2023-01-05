using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed;
    [SerializeField] GameObject[] _images;
    [SerializeField] private GameObject _explode;
    private Rigidbody _rb;
    private Touch _touch;
    private Animator _bucketAnim;

  
    
    

    private void Start() 
    {
        _rb = GetComponent<Rigidbody>();
        _bucketAnim = this.gameObject.transform.GetChild(0).GetComponent<Animator>(); 
        GameManager.Instance._canMove = false;
        Application.targetFrameRate = 60;
    }
    private void FixedUpdate() 
    {
        Movement();
    }
  void Movement()
    {

       if(GameManager.Instance._canMove)
       {
        Vector3 tmpPos = transform.position;
       tmpPos.x = Mathf.Clamp(tmpPos.x, -4f, 3.78f);
       transform.position = tmpPos;

       
           
       _rb.velocity = Vector3.forward * _speed * 1.5f ; 
       if (Input.touchCount > 0)
       {
           _touch = Input.GetTouch(0);
           
           if(_touch.phase == TouchPhase.Moved)
           { 
            Vector3 xInput = new Vector3(_touch.deltaPosition.x , 0 , 0);
             _rb.MovePosition(transform.position + xInput * Time.deltaTime * _turnSpeed); 
           }
       }
      
       }
       
    
    }
 
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("FinishLine"))
        {
            GameManager.Instance.Calculate();
            GameManager.Instance.LevelFinish();  
            _bucketAnim.SetTrigger("Split");
             StartCoroutine(SetActiveImageCD());
            
        }   
        if(other.CompareTag("Trap"))
        {
            GameManager.Instance.Fail();
            gameObject.SetActive(false);
          Instantiate(_explode , gameObject.transform.position ,gameObject.transform.rotation);
          
        }     
    }
    IEnumerator SetActiveImageCD()
    {
        yield return new WaitForSeconds(0.7f);
         for (int i = 0; i < _images.Length; i++)
            {
                _images[i].SetActive(true);
            }

    }
}