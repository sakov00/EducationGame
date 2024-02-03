using UnityEngine;

namespace Assets.Scripts.Player.MVC.Views
{
    public class PlayerView : MonoBehaviour
    {
        private static readonly string IsRunForAnimation = "IsRunForAnimation";
        private static readonly string IsGroundForAnimation = "IsGroundForAnimation";
        private static readonly string VerticalVelocityForAnimation = "VerticalVelocityForAnimation";
        private static readonly string IsHittedForAnimation = "IsHittedForAnimation";

        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;


        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Move(Vector2 vector)
        {
            _rigidbody2D.velocity = vector;
        }

        public void FlipHero()
        {
            if (_rigidbody2D.velocity.x > 0)
                _spriteRenderer.flipX = false;
            else if (_rigidbody2D.velocity.x < 0)
                _spriteRenderer.flipX = true;
        }

        public void SetRunAnimation(bool isRunning)
        {
            _animator.SetBool(IsRunForAnimation, isRunning);
        }

        public void SetGroundedAnimation(bool isGrounded)
        {
            _animator.SetBool(IsGroundForAnimation, isGrounded);
        }

        public void SetVerticalVelocityForAnimation()
        {
            _animator.SetFloat(VerticalVelocityForAnimation, _rigidbody2D.velocity.y);
        }

        public void SetHittedForAnimation()
        {
            _animator.SetTrigger(IsHittedForAnimation);
        }
    }
}
