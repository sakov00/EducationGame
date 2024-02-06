using Assets.Scripts.Components;
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
        private CheckLayer checkLayer;


        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            checkLayer = GetComponent<CheckLayer>();
        }

        private void FixedUpdate()
        {
            FlipHero();
            ActiveAnimations();
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

        private void ActiveAnimations()
        {
            _animator.SetBool(IsRunForAnimation, _rigidbody2D.velocity.x != 0);
            _animator.SetBool(IsGroundForAnimation, checkLayer.IsTouched);
            _animator.SetFloat(VerticalVelocityForAnimation, _rigidbody2D.velocity.y);
            //_animator.SetTrigger(IsHittedForAnimation);
        }
    }
}
