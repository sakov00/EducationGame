using Assets.Scripts.Interfaces;
using Assets.Scripts.Player.MVC.Controllers;
using Assets.Scripts.Player.MVC.Models;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Scripts.Components
{
    public class InteractableComponent : MonoBehaviour
    {
        [Inject] private PlayerModel playerModel;
        [Inject] private PlayerInputController playerInputController;
        [Inject] private UnityEvent<IInteractable> unityEvent;
        [Inject] private int interactionRadius;
        [Inject] private LayerMask intreactionLayerMask;

        private void Awake()
        {
            //need ManagerComponent one Component for several GameObjects
            playerInputController.AddListenerInteractEvent(Interact);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (playerModel.gameObject == collision.gameObject && unityEvent != null)
            {
                var interactObject = gameObject.GetComponent<IInteractable>();
                unityEvent.Invoke(interactObject);
                interactObject.Interact();
            }
        }

        private void Interact()
        {
            var interactionResult = new Collider2D[10];
            Physics2D.OverlapCircleNonAlloc(playerModel.transform.position, interactionRadius, interactionResult, intreactionLayerMask);

            for (int i = 0; i < interactionResult.Length; i++)
            {
                var interactableComponent = interactionResult[i]?.GetComponent<InteractableComponent>();
                if (interactableComponent != null)
                {
                    var interactObject = interactableComponent.gameObject.GetComponent<IInteractable>();
                    unityEvent.Invoke(interactObject);
                    interactObject.Interact();
                }    
            }
        }
    }
}
