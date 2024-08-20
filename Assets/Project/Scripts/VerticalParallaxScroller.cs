using UnityEngine;

public class VerticalParallaxScroller : MonoBehaviour
{
    public Transform playerTransform; 
    public GameObject[] backgroundSprites; 
    public float scrollSpeed = 0.5f; 

    private float spriteHeight; 
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; 
        if (backgroundSprites.Length > 0)
        {
             spriteHeight = backgroundSprites[0].GetComponent<SpriteRenderer>().bounds.size.y;
        }
    }

    void Update()
    {
         foreach (GameObject bg in backgroundSprites)
        {
            bg.transform.position += Vector3.up * scrollSpeed * Time.deltaTime;
        }

        RepositionBackgrounds();
    }

    void RepositionBackgrounds()
    {
        foreach (GameObject bg in backgroundSprites)
        {
            float cameraTopEdge = mainCamera.transform.position.y + mainCamera.orthographicSize;
            float bgBottomEdge = bg.transform.position.y - spriteHeight / 2;

            if (bgBottomEdge > cameraTopEdge)
            {
                GameObject lowestBg = GetLowestBackground();
                float newYPosition = lowestBg.transform.position.y - spriteHeight;
                bg.transform.position = new Vector3(bg.transform.position.x, newYPosition, bg.transform.position.z);
            }
        }
    }

    GameObject GetLowestBackground()
    {
        GameObject lowestBg = backgroundSprites[0];
        foreach (GameObject bg in backgroundSprites)
        {
            if (bg.transform.position.y < lowestBg.transform.position.y)
            {
                lowestBg = bg;
            }
        }
        return lowestBg;
    }
}

