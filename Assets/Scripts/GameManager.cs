using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public virtual bool IsDontDestroyOnLoad => true;
    public event System.Action OnDesireColors;
    public event System.Action OnCalculate;
    public event System.Action OnLevelFinish;
    public event System.Action OnFail;
    public float _numberofMainColors;
    public bool _leveldone;
    public bool _canMove = false;
   
    public int _redCount;
    public int _blueCount;
    public int _greenCount;
    public int _yellowCount;

    [SerializeField] private float _desireRedCount;
    [SerializeField] private float _desireBlueCount;
    [SerializeField] private  float _desireGreenCount;
    [SerializeField] private float _desireYellowCount;
    
    private float _accRed;
    private  float _accBlue;
    private float _accGreen;
    private float _accYellow;
    public float _accColor;
    void Awake()
    {
         Application.targetFrameRate = 60;
         if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
         else if (Instance != this) 
        {
            Destroy(Instance.gameObject);
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }
    private void OnDestroy()
    {
        if (Instance == this as GameManager)
        {
            Instance = null;
        }
    }
    private void Start() 
    {
       
       
    }
   
    public void DesareColors()
    {
        OnDesireColors?.Invoke();
       if(_redCount <= _desireRedCount && _desireRedCount!=0 )
       {
            _accRed = _redCount / _desireRedCount;
       }
       if(_blueCount <= _desireBlueCount && _desireBlueCount !=0 )
       {
            _accBlue = _blueCount / _desireBlueCount;
       }
        if(_greenCount <= _desireGreenCount &&_desireGreenCount !=0 )
       {
            _accGreen = _greenCount / _desireGreenCount;
       }
        if(_yellowCount <= _desireYellowCount && _desireYellowCount !=0 )
       {
            _accYellow = _yellowCount / _desireYellowCount;
       }
      
    }
     public void Calculate()
    {
        OnCalculate?.Invoke();   
        float _collectedColors =_redCount + _blueCount + _greenCount + _yellowCount;
        float _accColorSub = (_accRed +_accBlue +_accGreen +_accYellow)/_numberofMainColors;
        float _allDesireColors = _desireRedCount + _desireBlueCount + _desireGreenCount + _desireYellowCount;
        float _suballColors =  (_collectedColors- _allDesireColors)/(_collectedColors) ;

    if(_allDesireColors < _collectedColors)
    {
         _accColor = Mathf.Round((_accColorSub - Mathf.Abs(_suballColors) )*100);
    }
    if(_allDesireColors >= _collectedColors)
    {
        _accColor = Mathf.Round((_accColorSub)*100);
    }      
       
    }
     public void LevelFinish()
    {
        OnLevelFinish?.Invoke();  
       
        _leveldone = true;
        _canMove = false;
    }
    public void Fail()
    {
        OnFail?.Invoke();
        _canMove = false;
    }
    
}
