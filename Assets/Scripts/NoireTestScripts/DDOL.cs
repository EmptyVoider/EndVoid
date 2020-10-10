using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
{
	/*
	 * DDOL is basically a way of keeping certain data between scenes without it resetting to default values.
	 */
	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
		//Dont destroy the attatched to game object when a new scene loads.
	}
}
