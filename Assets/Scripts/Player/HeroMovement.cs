using Assets.Scripts.Components;
using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.PlayerComponents
{
    public class HeroMovement : MonoBehaviour
    {
        private static readonly string IsRunForAnimation = "IsRunForAnimation";
        private static readonly string IsGroundForAnimation = "IsGroundForAnimation";
        private static readonly string VerticalVelocityForAnimation = "VerticalVelocityForAnimation";
        private static readonly string IsHittedForAnimation = "IsHittedForAnimation";

        [SerializeField] private Hero hero;
        [SerializeField] private float speed;
        [SerializeField] private float jumpPower;
        [SerializeField] private float damageJumpPower;
        [SerializeField, HideInInspector] private CheckLayer checkLayer;

        private float horizontalInput;
        private float verticalInput;
        private float interactInput;
        private bool allowDoubleJump;
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;


        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void FixedUpdate()
        {
            Move();
            FlipHero();
            ActiveAnimations();
        }

        private void Move()
        {
            var horizontal = horizontalInput * speed;
            _rigidbody2D.velocity = new Vector2(horizontal, CalculateVerticalVelocity());
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
            if(!isFalling) return verticalY;

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

        private void FlipHero()
        {
            if (_rigidbody2D.velocity.x > 0)
                _spriteRenderer.flipX = false;
            else if (_rigidbody2D.velocity.x < 0)
                _spriteRenderer.flipX = true;
        }

        private void ActiveAnimations()
        {
            _animator.SetBool(IsRunForAnimation, (horizontalInput * speed) != 0);
            _animator.SetBool(IsGroundForAnimation, checkLayer.IsTouched);
            _animator.SetFloat(VerticalVelocityForAnimation, _rigidbody2D.velocity.y);
        }

        public void TakeDamage()
        {
            _animator.SetTrigger(IsHittedForAnimation);
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.y, damageJumpPower);
        }

        public void OnHorisontalMovement(InputAction.CallbackContext context) =>
            horizontalInput = context.ReadValue<float>();

        public void OnVerticalMovement(InputAction.CallbackContext context) =>
            verticalInput = context.ReadValue<float>();

        public void OnInteract(InputAction.CallbackContext context) =>
            hero.OnInteract(context);
    }
}