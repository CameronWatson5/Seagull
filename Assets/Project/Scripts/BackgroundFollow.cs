using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform seagullTransform; 
    public float verticalOffset = 0f; 
    public float followSpeed = 0.1f; 
    private Vector3 targetPosition;

    void Update()
    {
        targetPosition = new Vector3(transform.position.x, seagullTransform.position.y + verticalOffset, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}

