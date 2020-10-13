using System.Collections;
using System.Collections.Generic;
using Masks;
using UnityEngine;
using UnityEngine.UI;

public class MaskMenu : MonoBehaviour
{
    public Image Selector;
    public Image[] Images;
    public Sprite EmptyBox;
    private MaskInfo[] _masks;
    private int _maskindex;

    public void UpdateMasks(MaskInfo[] masks)
    {
        _masks = masks;
        for (int i = 0; i < Images.Length; i++)
        {

            if (i < masks.Length)
            {
                Images[i].sprite = _masks[i].FrontSprite;
                if (Images[i].sprite == null)
                {
                    Images[i].sprite = EmptyBox;
                }
            }
            else
            {
                Images[i].sprite = EmptyBox;
                    
            }
        }

    }

    public MaskInfo NextMask()
    { 
        _maskindex = (_maskindex + 1) % _masks.Length;
        Selector.transform.position = Images[_maskindex].transform.position;
        return _masks[_maskindex];
    }
}
