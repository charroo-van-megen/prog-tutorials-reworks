using UnityEngine;

public class JumpAndMove : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 5f;
    public float jumpForce = 20f;
    private bool onFloor = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Beweging
        float horizontal = Input.GetAxis("Horizontal"); // A/D of pijltjes links/rechts
        float vertical = Input.GetAxis("Vertical");     // W/S of pijltjes omhoog/omlaag

        Vector3 moveDirection = (transform.forward * vertical + transform.right * horizontal).normalized;
        Vector3 newVelocity = moveDirection * moveSpeed;
        newVelocity.y = rb.velocity.y; // behoud je sprong/snelheid op y-as
        rb.velocity = newVelocity;

        // Springen
        if (Input.GetKeyDown(KeyCode.Space) && onFloor == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onFloor = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            onFloor = true;
        }
    }
}
