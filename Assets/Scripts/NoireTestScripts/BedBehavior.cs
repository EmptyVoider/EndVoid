using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BedBehavior : MonoBehaviour
{
	public enum WorldType
	{
		Overworld, Nightmare, Dream
	}
	public WorldType currentWorld;
	public string toLoad;

	public Image blackImg;
	public Animator anim;
	public GameObject eyeBase;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (currentWorld == WorldType.Overworld)
		{
			int numOfWorld = Random.Range(1, 3);
			Debug.Log(numOfWorld);
			switch (numOfWorld)
			{
				case 1:
					toLoad = "NoireTestingDreamScene";
					break;
				case 2:
					toLoad = "NoireTestingNightmareScene";
					break;
				default:
					toLoad = "NoireTestingScene";
					break;
			}
		}
		else
		{
			toLoad = "NoireTestingScene";
		}
		
		StartCoroutine(Fading());

	}
	private IEnumerator Fading() 
	{
		
		Debug.Log("Fading");
		anim.SetBool("Fade", true);
		yield return new WaitUntil(() => blackImg.color.a == 1);
		eyeBase.GetComponent<Animator>().SetBool("Blinking", true);
		yield return new WaitForSecondsRealtime(2f);
		SceneManager.LoadScene(toLoad);
	}
}