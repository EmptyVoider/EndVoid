using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BedBehavior : MonoBehaviour
{
	/*
	 * Bed Behavior is for teleporting between worlds. 
	 * Can be altered to fit additional or fewer worlds. 
	 * Can be applied to different objs with slight modification.
	 * Includes enum for different worlds.
	 * Includes a fade effect when going between worlds. with the option to remove the eyes.
	 */
	public enum WorldType
	{
		Overworld, Nightmare, Dream
	}
	//Enum for world types, can include any world.
	public WorldType currentWorld;
	//Our currently loaded world, to be set in inspector.
	public string toLoad;
	//DO NOT TOUCH IN INSPECTOR, this string will be set in the switch later on and controls the next world to load.
	public Image blackImg;
	//Just a black image to fade to and from.
	public Animator anim;
	//Animator on the black image above which allows us to fade in and out.
	public GameObject eyeBase;
	//GameObject that holds both eye objects which should be accessed as a group through the eyeBase features.
	private void Start() 
	{
		GameObject canvas = FindObjectOfType<Canvas>().gameObject;
		//Get canvas of the world. temporarily.
		blackImg = canvas.transform.Find("BlackIMG").GetComponent<Image>();
		//Go through canvas to find the blackIMG and set it to our var above.
		anim = canvas.transform.Find("BlackIMG").GetComponent<Animator>();
		//Go through canvas to find the blackIMG and set its anim to our var above.
		eyeBase = canvas.transform.Find("EyePanel").gameObject;
		//Get the eyebase within the canvas and set it to our var above.

		//These above lines can be changed in the future if more objects besides warps use this script.
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (currentWorld == WorldType.Overworld)
		{
		//If our currentworld is the overworld.
			int numOfWorld = Random.Range(1, 3);
			//Random num either 1 or 2 atm, 3 is non inclusive. Can be changed to include more worlds or to have odds for different worlds.
			switch (numOfWorld)
			{
			//determine which num was rolled randomly. Change down here as well to include new worlds or change the odds for different worlds.
				case 1:
				//Called on a 1 roll.
					toLoad = "NoireTestingDreamScene";
					break;
				case 2:
				//Called on a 2 roll.
					toLoad = "NoireTestingNightmareScene";
					break;
				default:
				//Only called if anything other than the cases above is rolled.
					toLoad = "NoireTestingScene";
					break;
			}
		}
		else
		{
			toLoad = "NoireTestingScene";
			//Along with above statements that look the same, sets the string of the worlds name to load.
		}
		
		StartCoroutine(Fading());
		//Run a coroutine for fading.
	}
	private IEnumerator Fading() 
	{
		
		Debug.Log("Fading");
		anim.SetBool("Fade", true);
		//Set the black image animator variable for Fade to true so the fade to black begins.
		yield return new WaitUntil(() => blackImg.color.a == 1);
		//Wait until the black image is fully visible and no longer transparent.
		eyeBase.GetComponent<Animator>().SetBool("Blinking", true);
		//Set eyebase animator variable Blinking to true so the eyes blink closed.
		yield return new WaitForSecondsRealtime(2f);
		//Wait for eye animation to finish. Can be changed from hardcoded time.
		SceneManager.LoadScene(toLoad);
		//Load scene specified above.
		
	}
}