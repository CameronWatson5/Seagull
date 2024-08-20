using UnityEngine;

public class CameraMoveUp : MonoBehaviour
{
    public float speed = 0.5f; 

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}