using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	/*
	 * GameManager will be used for many more things but as of now it only creates the player at runtime so that there will be no duplicate players.
	 */
	public GameObject playerOBJ;
	//Reference to the prefab for player.
	private void Awake()
	{

		if (!GameObject.FindGameObjectWithTag("Player")) 
		//If player does not exist on launch.
		{
			Instantiate(playerOBJ);
			//Create instance of player prefab.
		}
	}
}
