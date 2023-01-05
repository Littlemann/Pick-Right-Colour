using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{
    [SerializeField] private GameObject _mLiquid;
    [SerializeField] private GameObject _mLiquidMesh;

    private int _mSloshSpeed =60;
    private int _mRotateSpeed = 15;
    private int _difference =25;

    private void Update() 
    {
        Slosh();

        _mLiquidMesh.transform.Rotate(Vector3.up * _mRotateSpeed * Time.deltaTime , Space.Self);
    }
    private void Slosh()
    {
        Quaternion inverseRotation = Quaternion.Inverse(transform.localRotation);
        Vector3 finalRotation = Quaternion.RotateTowards(_mLiquid.transform.localRotation , inverseRotation , _mSloshSpeed * Time.deltaTime).eulerAngles;

        finalRotation.x = ClampRotationValue(finalRotation.x, _difference);
        finalRotation.z = ClampRotationValue(finalRotation.z, _difference);

        _mLiquid.transform.localEulerAngles = finalRotation;
        
    }
    private float ClampRotationValue(float value , float _difference)
    {
        float returnValue = 0.0f;
        if(value > 180)
        {
            returnValue = Mathf.Clamp(value , 360 - _difference , 360);
        }
        else
        {
            returnValue = Mathf.Clamp(value , 0 , _difference);
           
        }
        return returnValue;
    }




}