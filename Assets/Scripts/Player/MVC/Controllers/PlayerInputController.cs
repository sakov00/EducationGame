using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Assets.Scripts.Player.MVC.Controllers
{
    public class PlayerInputController : MonoBehaviour
    {
        private float horizontalInput;
        private float verticalInput;

        public event Action<float, float> OnMovementEvent;
        public event Action OnInteractEvent;

        private void FixedUpdate()
        {
            OnMovementEvent.Invoke(horizontalInput, verticalInput);
        }

        private void OnHorisontalMovement(InputAction.CallbackContext context)
        {
            horizontalInput = context.ReadValue<float>();
        }

        private void OnVerticalMovement(InputAction.CallbackContext context)
        {  
            verticalInput = context.ReadValue<float>();
        }

        private void OnInteract(InputAction.CallbackContext context)
        {
            if(context.canceled)
                OnInteractEvent.Invoke();
        }

        public void AddListenerInteractEvent(Action action)
        {
            if(OnInteractEvent == null)
                OnInteractEvent += action;
        }
    }
}
