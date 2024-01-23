using UnityEngine;
using UnityEngine.InputSystem;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private Hero hero;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField, HideInInspector] private CheckLayer checkLayer;

    private float horizontalInput;
    private float verticalInput;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        var horizontal = horizontalInput * speed;
        _rigidbody2D.velocity = new Vector2(horizontal, _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        if (verticalInput > 0 && checkLayer.IsGrounded && _rigidbody2D.velocity.y <= 0)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    public void OnHorisontalMovement(InputAction.CallbackContext context) =>
        horizontalInput = context.ReadValue<float>();

    public void OnVerticalMovement(InputAction.CallbackContext context) =>
        verticalInput = context.ReadValue<float>();
}
