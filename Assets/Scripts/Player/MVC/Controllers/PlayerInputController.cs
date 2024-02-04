using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Assets.Scripts.Player.MVC.Controllers
{
    public class PlayerInputController : MonoBehaviour
    {
        private float horizontalInput;
        private float verticalInput;

        [Inject] private readonly PlayerMoveController moveController;

        void FixedUpdate()
        {
            moveController.Move(horizontalInput, verticalInput);
        }

        public void OnHorisontalMovement(InputAction.CallbackContext context) =>
            horizontalInput = context.ReadValue<float>();

        public void OnVerticalMovement(InputAction.CallbackContext context) =>
            verticalInput = context.ReadValue<float>();

        //public void OnInteract(InputAction.CallbackContext context)
            //interactInput.OnInteract(context);
    }
}
