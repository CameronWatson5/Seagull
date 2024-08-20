using UnityEngine;

public class PlayerPositionCheck : MonoBehaviour
{
    public Transform cameraTransform; 
    public float leftThreshold = -5f; 
    public float rightThreshold = 5f; 
    public float pushSpeed = 10f; 

    void Update()
    {
        if (transform.position.x > cameraTransform.position.x + rightThreshold)
        {
            transform.position += Vector3.left * pushSpeed * Time.deltaTime;
        }
        else if (transform.position.x < cameraTransform.position.x + leftThreshold)
        {
            transform.position += Vector3.right * pushSpeed * Time.deltaTime;
        }
    }
}

