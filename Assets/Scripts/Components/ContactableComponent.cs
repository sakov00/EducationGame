using Assets.Scripts.Interfaces;
using Assets.Scripts.Player.MVC.Models;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Scripts.Components
{
    public class ContactableComponent : MonoBehaviour
    {
        [Inject] private PlayerModel playerModel;
        [Inject] private UnityEvent<IContactable> unityEvent;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (playerModel.gameObject == collision.gameObject && unityEvent != null)
            {
                var concatObject = gameObject.GetComponent<IContactable>();
                unityEvent.Invoke(concatObject);
                concatObject.Contact();
            }
        }
    }
}
