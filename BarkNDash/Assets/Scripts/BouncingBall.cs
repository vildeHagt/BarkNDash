using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    public bool isOnGround = false;
    public bool touchesPlayer = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // Ignore collisions with obstacles
        int obstacleLayer = LayerMask.NameToLayer("Obstacle");
        int tennisBallLayer = gameObject.layer;

        if (obstacleLayer >= 0)
        {
            Physics2D.IgnoreLayerCollision(tennisBallLayer, obstacleLayer, true);
        }
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

    // Removed FixedUpdate to allow natural gravity-based falling
}
