using UnityEngine;

public class MoveNoRotation : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // Links/Rechts
        float moveZ = Input.GetAxis("Vertical");   // Vooruit/Achteruit

        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;

        transform.Translate(move, Space.World);
    }
}
