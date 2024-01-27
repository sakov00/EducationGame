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
        [SerializeField, HideInInspector] private CheckLayer checkLayer;

        private float horizontalInput;
        private float verticalInput;
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
            Jump();
            ActiveAnimations();

        }

        private void Move()
        {
            var horizontal = horizontalInput * speed;
            _rigidbody2D.velocity = new Vector2(horizontal, _rigidbody2D.velocity.y);
            if (_rigidbody2D.velocity.x > 0)
                _spriteRenderer.flipX = false;
            else if (_rigidbody2D.velocity.x < 0)
                _spriteRenderer.flipX = true;
        }

        private void Jump()
        {
            if (verticalInput > 0 && checkLayer.IsGrounded && _rigidbody2D.velocity.y <= 0)
            {
                _rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
        }

        private void ActiveAnimations()
        {
            _animator.SetBool(IsRunForAnimation, (horizontalInput * speed) != 0);
            _animator.SetBool(IsGroundForAnimation, checkLayer.IsGrounded);
            _animator.SetFloat(VerticalVelocityForAnimation, _rigidbody2D.velocity.y);
        }

        public void OnHorisontalMovement(InputAction.CallbackContext context) =>
            horizontalInput = context.ReadValue<float>();

        public void OnVerticalMovement(InputAction.CallbackContext context) =>
            verticalInput = context.ReadValue<float>();
    }
}