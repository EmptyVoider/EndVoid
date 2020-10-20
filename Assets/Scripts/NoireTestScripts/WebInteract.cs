using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WebInteract : MonoBehaviour
{
    Player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            player = collision.gameObject.GetComponent<Player>();
        }
        InvokeRepeating("StuckTest", 1f, 2f);
        Debug.Log("Next Call");
        InvokeRepeating("SpiderTest", 1f, 2f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CancelInvoke();
        StopCoroutine(Stick());
    }
	#region Sticky
	public void StuckTest()
    {
        float stuckChance = Random.Range(0f, 2f);
        if (stuckChance > 1.4f)
        {
            StartCoroutine(Stick());
        }
    }
    private IEnumerator Stick() 
    {
        Debug.Log("Stuck");
        float speed = player.pMove.moveSpeed;
        player.pMove.moveSpeed = 0;
        yield return new WaitForSeconds(1.5f);
        player.pMove.moveSpeed = speed;
        Debug.Log("UnStuck");
    }
    #endregion
    #region Spiders
    private void SpiderTest() 
    {
        float spiderChance = Random.Range(0f, 2f);
        if (spiderChance > 1.3f) 
        {
            MoveSpiders();
            CancelInvoke("SpiderTest");
        }
    }
    public void MoveSpiders() 
    {
        Vector2 lastPos = player.transform.position;
        //Move Spider towards player (needs navmesh and spider characters) 

    }
    #endregion
}
