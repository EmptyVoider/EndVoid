using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTest : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            Debug.Log("Default Layer");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Items";
            Debug.Log("Items Layer");
        }
    }
}
