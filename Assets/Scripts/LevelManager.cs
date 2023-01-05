using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    void Update()
    {
        GameManager.Instance.DesareColors();
       
    }
    private void OnEnable() 
    {
        GameManager.Instance.OnFail += LoadSameScene;
        GameManager.Instance.OnLevelFinish += StarScene;
    }
    private void StarScene()
    {
        StartCoroutine(LoadSceneCountDown());
    }
    
    IEnumerator LoadSceneCountDown()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("StarScene", LoadSceneMode.Additive);
        
    }
    private void LoadSameScene()
    {
        StartCoroutine(LoadSameSceneCountDown());
       
    }
    public void ReplayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator LoadSameSceneCountDown()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextSceneButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
   
  
}
