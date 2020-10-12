using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsPanel : MonoBehaviour
{
    public List<GameObject> itemsInPanel;
    


    public void AddItemToPanel(Item item) 
    {
        
        foreach (GameObject img in itemsInPanel) 
        {
            if (!img.activeSelf) 
            {
                Debug.Log("Item Added");
                img.SetActive(true);
                img.GetComponent<Image>().sprite = item.image;
                break;
            }
        }
    }
}
