using UnityEngine;
using UnityEngine.Serialization;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    [FormerlySerializedAs("background1")] public GameObject backgroundSky; 
    [FormerlySerializedAs("background2")] public GameObject backgroundSky2; 
    private float height;

    void Start()
    {
        height = backgroundSky.GetComponent<Renderer>().bounds.size.y;

        Vector3 startPosition2 = new Vector3(backgroundSky.transform.position.x, backgroundSky.transform.position.y + height, backgroundSky.transform.position.z);
        backgroundSky2.transform.position = startPosition2;
    }

    void Update()
    {
        backgroundSky.transform.position += Vector3.up * scrollSpeed * Time.deltaTime;
        backgroundSky2.transform.position += Vector3.up * scrollSpeed * Time.deltaTime;

        if (backgroundSky.transform.position.y >= height)
        {
            backgroundSky.transform.position = new Vector3(backgroundSky.transform.position.x, backgroundSky2.transform.position.y - height, backgroundSky.transform.position.z);
            GameObject temp = backgroundSky;
            backgroundSky = backgroundSky2;
            backgroundSky2 = temp;
        }
    }
}