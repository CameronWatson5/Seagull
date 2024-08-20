using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    public GameObject[] backgrounds;
    public float speed = -3.0f; 
    public float overlap = 0.1f;

    private float spriteHeight;

    void Start()
    {
        if (backgrounds.Length > 0)
        {
            spriteHeight = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.y;
        }
    }

    void Update()
    {
        MoveBackgrounds();
        RepositionBackgroundsIfNeeded();
    }

    void MoveBackgrounds()
    {
        foreach (GameObject bg in backgrounds)
        {
            bg.transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        }
    }

    void RepositionBackgroundsIfNeeded()
    {
        float cameraBottom = Camera.main.transform.position.y - Camera.main.orthographicSize;
        
        foreach (GameObject bg in backgrounds)
        {
            if (bg.transform.position.y + spriteHeight < cameraBottom)
            {
                float highestY = FindHighestBackgroundY();
                float newYPosition = highestY + spriteHeight - overlap;
                bg.transform.position = new Vector3(bg.transform.position.x, newYPosition, bg.transform.position.z);
                
             }
        }
    }

    float FindHighestBackgroundY()
    {
        float highestY = float.MinValue;
        foreach (GameObject bg in backgrounds)
        {
            float bgY = bg.transform.position.y;
            if (bgY > highestY)
            {
                highestY = bgY;
            }
        }
        return highestY;
    }
}


