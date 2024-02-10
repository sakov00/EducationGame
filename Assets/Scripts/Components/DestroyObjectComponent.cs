using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public class DestroyObjectComponent : MonoBehaviour
    {
        public void DestroyObject(GameObject gameObject)
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }

        public void DestroyObject(IInteractable interactObject)
        {
            if (interactObject != null)
            {
            }
        }
    }
}
