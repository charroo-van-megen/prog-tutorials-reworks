using UnityEngine;

public class Animate : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Enter key
        {
            Debug.Log("Enter pressed - triggering Punch");
            animator.SetTrigger("Punch");
        }
    }
}
