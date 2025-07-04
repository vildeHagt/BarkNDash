using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    public bool isOnGround = true;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
        animator.SetBool("isJumping", !isOnGround);
    }
}
