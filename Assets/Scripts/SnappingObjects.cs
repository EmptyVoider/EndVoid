using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnappingObjects : MonoBehaviour
{
    private Vector2 newPos;
    private bool shouldSnap;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        shouldSnap = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        var currentPos = transform.position;
        newPos = new Vector2(Mathf.Round(currentPos.x), Mathf.Round(currentPos.y) - 0.5f);//this is the snapping
        shouldSnap = true;
        }
    }

    void FixedUpdate()
    {
        if (shouldSnap)
        {
        transform.position = Vector2.Lerp(transform.position, newPos, .5f);//and i try to smooth it here, but it doesnt work yet...
        }
    }
}
