using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(0, 0, -10); 
    public float followSpeed = 2f; 

    void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset; 
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime); 
        transform.position = smoothedPosition; 
    }
}