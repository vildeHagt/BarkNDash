using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            ContactPoint2D contact = collision.GetContact(0);

            Vector2 normal = contact.normal;

            // side collision
            if (Mathf.Abs(normal.x) > Mathf.Abs(normal.y))
            {
                GameController.Instance.GameOver();
            }
        }
    }
}
