using UnityEngine;

namespace Triggers
{
    [RequireComponent(typeof(Collider2D))]
    public class GenericTrigger : MonoBehaviour
    {
        public GameObject[] ObjectsToTrigger;
        public bool SingleUse;

        private void OnTriggerEnter2D(Collider2D other)
        {
            foreach (var triggerableObject in ObjectsToTrigger)
            {
                if (!triggerableObject.gameObject.activeInHierarchy)
                {
                    triggerableObject.gameObject.SetActive(true);
                }
            }

            if (SingleUse)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
