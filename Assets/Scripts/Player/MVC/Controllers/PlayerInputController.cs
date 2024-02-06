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

        private void FixedUpdate()
        {
            OnMovementEvent.Invoke(horizontalInput, verticalInput);
        }

        public void OnHorisontalMovement(InputAction.CallbackContext context)
        {
            horizontalInput = context.ReadValue<float>();
        }
        public void OnVerticalMovement(InputAction.CallbackContext context)
        {  
            verticalInput = context.ReadValue<float>();
        }

        //public void OnInteract(InputAction.CallbackContext context)
            //interactInput.OnInteract(context);
    }
}
