using UnityEngine;

public class BackgroundCycler : MonoBehaviour
{
    public GameObject backgroundFar; 
    public GameObject backgroundFar2; 
    public float speed = 5f; 

    private float height; 

    void Start()
    {
        height = backgroundFar.GetComponent<Renderer>().bounds.size.y;
        backgroundFar2.transform.position = new Vector2(backgroundFar.transform.position.x, backgroundFar.transform.position.y + height);
    }

    void Update()
    {
        backgroundFar.transform.position += Vector3.up * speed * Time.deltaTime;
        backgroundFar2.transform.position += Vector3.up * speed * Time.deltaTime;

        if (backgroundFar.transform.position.y >= Camera.main.transform.position.y + Camera.main.orthographicSize + height)
        {
            backgroundFar.transform.position = new Vector2(backgroundFar2.transform.position.x, backgroundFar2.transform.position.y - height);
        }

        if (backgroundFar2.transform.position.y >= Camera.main.transform.position.y + Camera.main.orthographicSize + height)
        {
            backgroundFar2.transform.position = new Vector2(backgroundFar.transform.position.x, backgroundFar.transform.position.y - height);
        }
    }
}