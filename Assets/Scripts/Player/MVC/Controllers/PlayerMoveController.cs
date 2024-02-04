using Assets.Scripts.Components;
using Assets.Scripts.Player.MVC.Models;
using Assets.Scripts.Player.MVC.Views;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.MVC.Controllers
{
    public class PlayerMoveController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpPower;
        [SerializeField] private float damageJumpPower;

        private float horizontalInput;
        private float verticalInput;
        private bool allowDoubleJump;
        private Rigidbody2D _rigidbody2D;
        private CheckLayer checkLayer;

        [Inject] private readonly PlayerModel playerModel;
        [Inject] private readonly PlayerView playerView;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            checkLayer = GetComponent<CheckLayer>();
        }

        public void Move(float horizontalInput, float verticalInput)
        {
            this.horizontalInput = horizontalInput;
            this.verticalInput = verticalInput;
            var vectorMove = new Vector2(CalculateHorizontalVelocity(), CalculateVerticalVelocity());
            playerView.Move(vectorMove);
            playerView.FlipHero();
            ActiveAnimations();
        }

        private void ActiveAnimations()
        {
            playerView.SetRunAnimation(horizontalInput != 0);
            playerView.SetGroundedAnimation(checkLayer.IsTouched);
            playerView.SetVerticalVelocityForAnimation();
        }

        private float CalculateHorizontalVelocity() 
        {
            return horizontalInput * speed;
        }

        private float CalculateVerticalVelocity()
        {
            var verticalY = _rigidbody2D.velocity.y;
            var isJumpPressed = verticalInput > 0;

            if (checkLayer.IsTouched)
                allowDoubleJump = true;

            if (isJumpPressed)
            {
                verticalY = CalculateJumpVelocity(verticalY);
            }
            else if (_rigidbody2D.velocity.y > 0)
            {
                verticalY *= 0.5f;
            }
            return verticalY;
        }

        private float CalculateJumpVelocity(float verticalY)
        {
            var isFalling = _rigidbody2D.velocity.y <= 0.001f;
            if (!isFalling) return verticalY;

            if (checkLayer.IsTouched)
            {
                verticalY += jumpPower;
            }
            else if (allowDoubleJump)
            {
                verticalY = jumpPower;
                allowDoubleJump = false;
            }
            return verticalY;
        }
    }
}
