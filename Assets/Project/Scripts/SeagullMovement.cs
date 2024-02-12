using UnityEngine;

public class SeagullMovement : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the seagull's movement

    void Update()
    {
        // Get input from arrow keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create a movement vector
        Vector3 movement = new Vector3(horizontal, vertical, 0);

        // Apply the movement to the seagull's position
        transform.position += movement * speed * Time.deltaTime;
    }
}