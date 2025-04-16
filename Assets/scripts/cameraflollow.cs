using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;              // The object (usually the player) to follow

    [Header("Position Settings")]
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Offset from the player
    public float followSpeed = 5f;        // How fast the camera follows

    [Header("Rotation Settings")]
    public bool lookAtTarget = true;      // Should the camera look at the target?
    public Vector3 rotationOffset;        // Optional rotation offset when looking at the player

    void LateUpdate()
    {
        if (target == null) return;

        // Smoothly move the camera to the target position with offset
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Optional: Look at the player
        if (lookAtTarget)
        {
            Vector3 lookDirection = target.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection) * Quaternion.Euler(rotationOffset);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, followSpeed * Time.deltaTime);
        }
    }
}
