using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Components
{
    public class InteractableComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent action;

        public void Interact()
        {
            action?.Invoke();
        }
    }
}
