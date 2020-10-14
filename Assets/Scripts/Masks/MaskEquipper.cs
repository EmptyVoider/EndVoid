using System;
using UnityEngine;

namespace Masks
{
    public class MaskEquipper : MonoBehaviour
    {
        private MaskMenu _maskMenu;
        private MaskSwitch _maskSwitch;

        private void Start()
        {
            var masks = GetComponentsInChildren<MaskInfo>();
            _maskMenu = FindObjectOfType<MaskMenu>();
            _maskSwitch = FindObjectOfType<MaskSwitch>();
            _maskMenu.UpdateMasks(masks);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                var mask = _maskMenu.NextMask();
                _maskSwitch.PutMask(mask);
            }

        }
        
    }
    
}