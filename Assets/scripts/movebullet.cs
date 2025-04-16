using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speed = 500f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = transform.forward * speed * Time.fixedDeltaTime;
    }
}
