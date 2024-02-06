using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Scripts.Components
{
    //need generic
    public class EnterTrigger : MonoBehaviour
    {
        [Inject] private GameObject targetGameObject;
        [Inject] private UnityEvent<GameObject> unityEvent;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (targetGameObject == collision.gameObject && unityEvent != null)
            {
                unityEvent.Invoke(gameObject);
            }
        }
    }
}
