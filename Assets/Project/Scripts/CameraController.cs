using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float minX = -10f;
    public float maxX = 10f;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX); 
        transform.position = pos;
    }
}

