using UnityEngine;

public class CameraMoveUp : MonoBehaviour
{
    public float speed = 0.5f; // Speed at which the camera moves up

    void Update()
    {
        // Move the camera up at a constant speed
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}