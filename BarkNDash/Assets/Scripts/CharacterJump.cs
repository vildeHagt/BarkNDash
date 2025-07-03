using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterJump : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jump;
    private bool isGrounded = true;
    private PlayerInput playerInput;
    private InputAction touchAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchAction = playerInput.actions["TouchPress"];
    }

    private void OnEnable()
    {
        touchAction.performed += TouchPressed;
    }

    private void OnDisable()
    {
        touchAction.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            Debug.Log("player jump");
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player has landed on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
