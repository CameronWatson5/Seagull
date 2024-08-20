using UnityEngine;

public class SeagullAnimatorController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (IsMovingUp())
        {
            animator.Play("SeagullAnimation");
        }
        else if (IsMovingDown())
        {
            animator.Play("SeagullAnimation");
        }
        else if (IsMovingLeft())
        {
            animator.Play("SeagullAnimationLeft");
        }
        else if (IsMovingRight())
        {
            animator.Play("SeagullAnimationRight");
        }
        else
        {
            animator.Play("SeagullAnimation");
        }
    }

    bool IsMovingUp()
    {
        return true;}

    bool IsMovingDown()
    {
        return true;}

    bool IsMovingLeft()
    {
        return true;}

    bool IsMovingRight()
    {
        return true;
    }
}