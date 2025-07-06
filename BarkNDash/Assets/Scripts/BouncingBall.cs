using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    public bool isOnGround = false;
    public bool touchesPlayer = false;
    public float speed = 5f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
        animator.SetBool("isOnGround", isOnGround);

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
            Score.Instance.AddPoints(100);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
        animator.SetBool("isOnGround", isOnGround);
    }

    private void FixedUpdate()
    {
        Vector2 newPosition = rb.position + Vector2.down * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}
