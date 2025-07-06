using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterJump : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction touchPressAction;
    private Rigidbody2D rb;
    private Animator animator;

    public float jump;
    public bool isOnGround = true;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions["TouchPress"];
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;
    }

    private void OnDisable()
    {
        touchPressAction.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        if (rb != null && isOnGround == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
            isOnGround = false;
            animator.SetBool("isJumping", !isOnGround);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Reward")
        {
            isOnGround = true;
            animator.SetBool("isJumping", !isOnGround);
        }
    }

    private void FixedUpdate()
    {
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
    }
}
