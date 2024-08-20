using UnityEngine;


public class SeagullMovement : MonoBehaviour
{
    public float speed = 5f;
    public Camera mainCamera;
    private Animator animator;
    private Vector3 lastPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;
        Vector3 newPos = transform.position + movement;

        Vector3 viewPos = mainCamera.WorldToViewportPoint(newPos);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        transform.position = mainCamera.ViewportToWorldPoint(viewPos);

        SetAnimationDirection(horizontalInput, verticalInput);

        lastPosition = transform.position;
    }

    void SetAnimationDirection(float horizontal, float vertical)
    {
        Vector2 direction = new Vector2(horizontal, vertical).normalized;

        if (direction.y > 0 && direction.x > 0)
        {
            animator.Play("SeagullAnimationUpRight");
        }
        else if (direction.y > 0 && direction.x < 0)
        {
            animator.Play("SeagullAnimationUpLeft");
        }
        else if (direction.y < 0 && direction.x > 0)
        {
            animator.Play("SeagullAnimationDownRight");
        }
        
        else if (direction.y < 0 && direction.x < 0)
        {
            animator.Play("SeagullAnimationDownLeft");
        }
        else if (direction.y > 0)
        {
            animator.Play("SeagullAnimationUp");
        }
        else if (direction.y < 0)
        {
            animator.Play("SeagullAnimationDown");
        }
        else if (direction.x > 0)
        {
            animator.Play("SeagullAnimationRight");
        }
        else if (direction.x < 0)
        {
            animator.Play("SeagullAnimationLeft");
        }
        else
        {
            animator.Play("SeagullAnimation"); 
        }
    }
}

