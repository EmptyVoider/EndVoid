using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    /*
     * Player basic stat setup w/ reposition for exiting beds.
     * 
     * can be revised to keep player stats/effects as a Scriptable Object or something serializable for saving purposes.
     */

    public PlayerMovement pMove;
    //Access to the player movement script.
    public List<Item> collectables;
    //A list of all collectables in the players inventory.
    private void Start()
    {
        pMove = GetComponent<PlayerMovement>();
        //Obtaining the player movement script.
        SceneManager.sceneLoaded += SetPositionNearBed;
        //Setting 'SceneLoaded' (when new scene is done loading) to have a trigger function in SetPositionNearBed(). More can be added.
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            ShadowForm form = transform.GetComponentInChildren<ShadowForm>();
            if (form.shadowForm)
            {
                form.ExitShadowForm();
            }
            else
            {
                form.EnterShadowForm();
            }
        }
    }
    //The ability to change stats based on whatever item is input, grabbing its effects.
    public void ChangeStats(Item item) 
    {
        //for every effect on the item use the switch.
        foreach (ItemEffects effect in item.effects) 
        {
            //Determine which effect is to be added. can be improved.
            switch (effect) 
            {
                //As of now it will only work if the effect is added to the enum and added as an actual stat change here.
                case ItemEffects.IncreaseSpeed:
                    pMove.moveSpeed += 2;
                    break;
                case ItemEffects.DecreaseSpeed:
                    pMove.moveSpeed -= 2;
                    break;
                default:
                    break;
            }
        }
    }
    //Only used to set position of player after exiting bed. possibly can be merged elsewhere or remade to fit multiple purposes.
    //Dont worry about the params, they are only if we want to do something when the scene loads and which scene it is. can be used later.
    private void SetPositionNearBed(Scene scene, LoadSceneMode mode) 
    {
        //getting the bed Position by finding the bed tagged obj in scene.
        Transform bedPos = GameObject.FindGameObjectWithTag("Bed").transform;
        //setting the player position to be 2 units to the side of the bed making it look like the player just exited bed.
        gameObject.transform.position = new Vector2(bedPos.position.x + 2, bedPos.position.y);
        //Start on wake.
        StartCoroutine(RestedUp());
    }
    private IEnumerator RestedUp() 
    {
        //Temporarily increase movespeed by 3 for 2 seconds. Can be altered to add running animation, change run time, add more features, etc.
        pMove.moveSpeed += 3;
        yield return new WaitForSecondsRealtime(2f);
        pMove.moveSpeed -= 3;
    }
}   
