using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEyes : MonoBehaviour
{
    GameObject eyeLeft, eyeRight;
    void Start()
    {
        eyeLeft = transform.GetChild(0).gameObject;
        eyeRight = transform.GetChild(1).gameObject;
    }

    public void ChangeLeft(bool enabled) 
    {
        if (enabled) 
        {
            eyeLeft.SetActive(true);
        }
        else 
        {
            eyeLeft.SetActive(false);
        }
    }
    public void ChangeRight(bool enabled) 
    {
        if (enabled)
        {
            eyeRight.SetActive(true);
        }
        else
        {
            eyeRight.SetActive(false);
        }
    }
        
}
