using Assets.Scripts.Interfaces;
using Assets.Scripts.Player.MVC.Models;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Scripts.Components
{
    public class InteractableComponent : MonoBehaviour
    {
        [Inject] private PlayerModel playerModel;
        [Inject] private UnityEvent<IInteractable> unityEvent;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (playerModel.gameObject == collision.gameObject && unityEvent != null)
            {
                var interactObject = gameObject.GetComponent<IInteractable>();
                unityEvent.Invoke(interactObject);
                interactObject.Interact();
            }
        }
    }
}
