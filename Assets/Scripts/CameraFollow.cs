using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    void FixedUpdate()
    {
        if (!target)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        Vector3 interpolatedPosition = Vector3.Lerp(transform.position, target.position + offset, 0.05f);//here you can change camera smoothness
        transform.position = interpolatedPosition;
       // transform.position = target.position + offset;
    }
}
