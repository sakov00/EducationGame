using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Components
{
    //need generic
    public class EnterTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject targetGameObject;
        [SerializeField] private UnityEvent unityEvent;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (targetGameObject == collision.GameObject() && unityEvent != null)
            {
                unityEvent.Invoke();
            }
        }
    }
}
