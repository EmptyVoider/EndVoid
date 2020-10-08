using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnappingObjects : MonoBehaviour
{
    public Vector2 newPos;
    public bool shouldSnap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        shouldSnap = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var currentPos = transform.position;
        newPos = new Vector2(Mathf.Round(currentPos.x), Mathf.Round(currentPos.y));//this is the snapping
        shouldSnap = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shouldSnap)
        {
        transform.position = Vector2.Lerp(transform.position, newPos, .5f);//and i try to smooth it here, but it doesnt work yet...
        }
    }
}
