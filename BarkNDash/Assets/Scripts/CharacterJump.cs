using UnityEngine;
using UnityEngine.InputSystem; // Required for PlayerInput

public class CharacterJump : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jump;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("PlayerJump script started. Rigidbody2D component: " + rb);
    }

    // This method will be called by PlayerInput when the "Jump" action is triggered
    public void OnJump(InputAction.CallbackContext context)
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
