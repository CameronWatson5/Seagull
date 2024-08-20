using UnityEngine;

public class DynamicBackgroundManager : MonoBehaviour
{
    public Transform player; 
    public GameObject[] backgrounds; 
    public float bufferDistance = 10f; 
    public float overlap = 0.1f; 

    private float spriteHeight;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        if (backgrounds.Length > 0)
        {
            spriteHeight = backgrounds[0].GetComponent<Renderer>().bounds.size.y;
        }
    }

    void Update()
    {
        AdjustBackgrounds();
    }

    void AdjustBackgrounds()
    {
        float cameraTop = mainCamera.transform.position.y + mainCamera.orthographicSize + bufferDistance;
        float cameraBottom = mainCamera.transform.position.y - mainCamera.orthographicSize - bufferDistance;

        float highestBgY = float.MinValue;
        float lowestBgY = float.MaxValue;

        foreach (GameObject bg in backgrounds)
        {
            float bgY = bg.transform.position.y;
            if (bgY > highestBgY)
            {
                highestBgY = bgY;
            }
            if (bgY < lowestBgY)
            {
                lowestBgY = bgY;
            }
        }

        foreach (GameObject bg in backgrounds)
        {
            if (bg.transform.position.y - spriteHeight > cameraTop)
            {
                bg.transform.position = new Vector3(bg.transform.position.x, lowestBgY - spriteHeight + overlap, bg.transform.position.z);
                UpdateBounds(ref highestBgY, ref lowestBgY, bg.transform.position.y);
            }
            else if (bg.transform.position.y + spriteHeight < cameraBottom)
            {
                bg.transform.position = new Vector3(bg.transform.position.x, highestBgY + spriteHeight - overlap, bg.transform.position.z);
                UpdateBounds(ref highestBgY, ref lowestBgY, bg.transform.position.y);
            }
        }
    }

    void UpdateBounds(ref float highestY, ref float lowestY, float newY)
    {
        if (newY > highestY) highestY = newY;
        if (newY < lowestY) lowestY = newY;
    }
}