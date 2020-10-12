using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : MonoBehaviour
{
	/*
	 * Script for possibly all items that adds an interactive component. as of now is only for collectables.
	 * By: Noire
	 */

	public Player p;
	//Player script access.
	public Item item;
	//The item that information that this script is attatched to. basically the Scriptable Object held by this obj for stat changes.
	private void OnTriggerStay2D(Collider2D collision) 
	{
		p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		//Getting access to the player gameobject only when stepped on. can be changed to detect if it is player or not stepping on it.
		if (!p.collectables.Contains(item))
		//If the list in player 'collectables' does not have the current item already.
		{
			p.AddItemToPanel(item);
			p.collectables.Add(item);
			//Add item data to collectables.
			p.ChangeStats(item);
			//Change player stats based on item effects.
			if (transform.parent)
			{
				Destroy(transform.parent.gameObject);
			}
			else
			{
				Destroy(this.gameObject);
			}
		}
	}
}
