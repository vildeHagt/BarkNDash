using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    public float buffer = 1f; // Extra space beyond the screen before destroying

    void Update()
    {
        // Get the main camera
        Camera cam = Camera.main;
        if (cam == null) return;

        // Convert the object's position to viewport coordinates (0-1 is on screen)
        Vector3 viewportPos = cam.WorldToViewportPoint(transform.position);

        // If the object is completely off the left side, destroy it
        if (viewportPos.x < 0 - buffer || viewportPos.x > 1 + buffer)
        {
            Destroy(gameObject);
        }
    }
}