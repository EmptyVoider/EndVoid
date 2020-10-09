using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace DefaultNamespace
{
    public class Debug : MonoBehaviour
    {
        private void Update()
        {
            //TODO Temporary, should be done as part of a menu
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}