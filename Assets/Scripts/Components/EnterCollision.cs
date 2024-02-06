using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Scripts.Components
{
    public class EnterCollision : MonoBehaviour
    {
        [SerializeField] private GameObject targetGameObject;
        [SerializeField] private UnityEvent<GameObject> unityEvent;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (targetGameObject == collision.gameObject && unityEvent != null)
            {
                unityEvent.Invoke(collision.gameObject);
            }
        }

        [SerializeField]
        public class EnterEvent : UnityEvent<GameObject>
        { }
    }
}
