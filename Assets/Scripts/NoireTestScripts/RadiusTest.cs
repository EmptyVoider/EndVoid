using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusTest : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			transform.parent.GetComponent<BearTest>().triggerable = true;
			Debug.Log("Triggerable = true");
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			transform.parent.GetComponent<BearTest>().triggerable = false;
			Debug.Log("Triggerable = false");
		}
	}
}
