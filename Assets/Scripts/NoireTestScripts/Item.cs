using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Item Effects and the Scriptable object setup for new items.
 */
public enum ItemEffects 
{
	IncreaseSpeed, DecreaseSpeed
}
//ItemEffects must have the buff/debuff that the item itself should have. Name only.
[CreateAssetMenu(fileName = "NewItem", menuName = "Create Item")]
//Setting up an assetmenu button to create a  new scriptable objet for an item.
public class Item :	ScriptableObject
{
	public string itemName;
	//Item Name
	public ItemEffects[] effects;
	//Array of effects, can include literally all effects or none.
	[TextArea(3, 25)]
	public string description;
	//Description of the item.
}
