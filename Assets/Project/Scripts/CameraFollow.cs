using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Target to follow (seagull)
    public Vector3 offset = new Vector3(0, 0, -10); // Offset from the target
    public float followSpeed = 2f; // How quickly the camera catches up to the target

    void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset; // Desired camera position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime); // Smoothly move towards the target
        transform.position = smoothedPosition; // Update camera position
    }
}