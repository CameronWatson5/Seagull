using UnityEngine;

public class BackgroundCycler : MonoBehaviour
{
    public GameObject backgroundFar; // Assign BackgroundFar here in the inspector
    public GameObject backgroundFar2; // Assign BackgroundFar2 here in the inspector
    public float speed = 5f; // Speed at which the backgrounds move up

    private float height; // Height of the backgrounds

    void Start()
    {
        // Assuming both backgrounds are the same size and perfectly aligned vertically for seamless tiling
        height = backgroundFar.GetComponent<Renderer>().bounds.size.y;

        // Ensure BackgroundFar2 is positioned immediately above BackgroundFar
        backgroundFar2.transform.position = new Vector2(backgroundFar.transform.position.x, backgroundFar.transform.position.y + height);
    }

    void Update()
    {
        // Move each background up
        backgroundFar.transform.position += Vector3.up * speed * Time.deltaTime;
        backgroundFar2.transform.position += Vector3.up * speed * Time.deltaTime;

        // Check if BackgroundFar has moved fully out of view and reset its position
        if (backgroundFar.transform.position.y >= Camera.main.transform.position.y + Camera.main.orthographicSize + height)
        {
            backgroundFar.transform.position = new Vector2(backgroundFar2.transform.position.x, backgroundFar2.transform.position.y - height);
        }

        // Similarly, check for BackgroundFar2
        if (backgroundFar2.transform.position.y >= Camera.main.transform.position.y + Camera.main.orthographicSize + height)
        {
            backgroundFar2.transform.position = new Vector2(backgroundFar.transform.position.x, backgroundFar.transform.position.y - height);
        }
    }
}