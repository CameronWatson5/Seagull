using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    public GameObject background1; // Assign your first background GameObject here
    public GameObject background2; // Assign a duplicate of your first background GameObject here

    private float height;

    void Start()
    {
        // Assuming both backgrounds have the same height in Unity units
        height = background1.GetComponent<Renderer>().bounds.size.y;

        // Position the second background right above the first one
        Vector3 startPosition2 = new Vector3(background1.transform.position.x, background1.transform.position.y + height, background1.transform.position.z);
        background2.transform.position = startPosition2;
    }

    void Update()
    {
        // Move both backgrounds up
        background1.transform.position += Vector3.up * scrollSpeed * Time.deltaTime;
        background2.transform.position += Vector3.up * scrollSpeed * Time.deltaTime;

        // Check if the first background has moved completely out of view
        if (background1.transform.position.y >= height)
        {
            // Move it above the second background
            background1.transform.position = new Vector3(background1.transform.position.x, background2.transform.position.y - height, background1.transform.position.z);
            // Swap the backgrounds so the first is now the second and vice versa
            GameObject temp = background1;
            background1 = background2;
            background2 = temp;
        }
    }
}