using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 newPosition = rb.position + Vector2.left * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}
