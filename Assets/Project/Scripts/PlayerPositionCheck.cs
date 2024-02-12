using UnityEngine;

public class PlayerPositionCheck : MonoBehaviour
{
    public Transform cameraTransform; // Assign the camera's transform in the inspector
    public float threshold = -20f; // How low the player can go before being pushed up. Adjust as needed.
    public float pushUpSpeed = 10f; // Speed at which the player is pushed up

    void Update()
    {
        // Check if the player is below the threshold
        if (transform.position.y < cameraTransform.position.y + threshold)
        {
            // Push the player up
            transform.position += Vector3.up * pushUpSpeed * Time.deltaTime;
        }
    }
}

