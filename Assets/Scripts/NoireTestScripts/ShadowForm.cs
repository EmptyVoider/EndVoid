using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowForm : MonoBehaviour
{
	Color darkColor;
	Color baseColor;
	Vector2 stopPos;
	public bool shadowForm;
	SpriteRenderer spRend;
	LineRenderer lRend;
	public void EnterShadowForm() 
	{
		stopPos = transform.parent.position;
		shadowForm = true;
		spRend.enabled = true;
		lRend.enabled = true;
		transform.GetComponentInParent<BoxCollider2D>().isTrigger = true;
		lRend.SetPosition(0, stopPos);
	}
	public void ExitShadowForm() 
	{
		//Play Animation
		transform.parent.position = stopPos;
		shadowForm = false;
		spRend.enabled = false;
		lRend.enabled = false;
		transform.GetComponentInParent<BoxCollider2D>().isTrigger = false;
	}
	private void Start()
	{
		spRend = GetComponent<SpriteRenderer>();
		lRend = GetComponent<LineRenderer>();
		spRend.enabled = false;
		lRend.enabled = false;
	}
	private void LateUpdate()
	{
		if (shadowForm) 
		{
			transform.position = stopPos;
			lRend.SetPosition(1, transform.parent.position);
		}

	}
}
