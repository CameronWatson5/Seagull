using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D backgroundCollider;
    private float backgroundSize;

    void Start()
    {
        backgroundCollider = GetComponent<BoxCollider2D>();
        backgroundSize = backgroundCollider.size.x;
    }

    void Update()
    {
        if(transform.position.x < -backgroundSize)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(backgroundSize * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}

