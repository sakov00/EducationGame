using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player.MVC.Controllers
{
    public class PlayerInputController : MonoBehaviour
    {
        private float horizontalInput;
        private float verticalInput;
        private PlayerMoveController moveController;

        private void Awake()
        {
            moveController = GetComponent<PlayerMoveController>();
        }

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
