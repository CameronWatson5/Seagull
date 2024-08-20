using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Transform player; 
    public GameObject[] backgroundSprites; 
    public float bufferZone = 10f; 
    private float spriteHeight;
    void Start()
    {
        if (backgroundSprites.Length > 0)
        {
            spriteHeight = backgroundSprites[0].GetComponent<Renderer>().bounds.size.y;
        }
    }

    void Update()
    {
        RepositionBackgrounds();
    }

    void RepositionBackgrounds()
    {
        float highestPoint = float.MinValue;
        float lowestPoint = float.MaxValue;

        foreach (var bg in backgroundSprites)
        {
            if (bg.transform.position.y > highestPoint) highestPoint = bg.transform.position.y;
            if (bg.transform.position.y < lowestPoint) lowestPoint = bg.transform.position.y;
        }

       if (player.position.y + bufferZone > highestPoint - spriteHeight)
        {
            GameObject lowestBg = null;
            foreach (var bg in backgroundSprites)
            {
                if (lowestBg == null || bg.transform.position.y < lowestBg.transform.position.y)
                {
                    lowestBg = bg;
                }
            }

            if (lowestBg != null)
            {
                lowestBg.transform.position = new Vector3(lowestBg.transform.position.x, highestPoint + spriteHeight, lowestBg.transform.position.z);
            }
        }
  }
}
