using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Components
{
    //need generic
    public class EnterTrigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent unityEvent;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponents<Hero>() != null && unityEvent != null)
            {
                unityEvent.Invoke();
            }
        }
    }
}
