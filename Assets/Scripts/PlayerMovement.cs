using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float screenLimit = 8.5f; // Adjust based on your camera size

    void Update()
    {
        // Get input from A/D or Left/Right arrow keys (-1 to 1)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the new position
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        transform.position += direction * moveSpeed;

        // Keep the player within the screen boundaries
        float clampedX = Mathf.Clamp(transform.position.x, -screenLimit, screenLimit);
        transform.position = new Vector2(clampedX, transform.position.y);
    }
}