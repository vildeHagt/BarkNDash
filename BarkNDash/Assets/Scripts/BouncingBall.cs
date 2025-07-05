using UnityEngine;
using UnityEngine.InputSystem;

public class BouncingBall : MonoBehaviour
{
    private Animator animator;
    public bool isOnGround = false;
    public bool touchesPlayer = false;
    private Score score = new();

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
        animator.SetBool("isOnGround", isOnGround);

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
            score.AddPoints(100); 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
        animator.SetBool("isOnGround", isOnGround);
    }
}
