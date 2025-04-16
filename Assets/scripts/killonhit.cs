using UnityEngine;

public class KillOnHit : MonoBehaviour
{
    public string targetTag = "Player";
    public GameObject effect;
    private AudioSource audioSource;
    private Hearts heartsScript;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

#if UNITY_EDITOR
        // Debug check if the target tag exists
        bool tagFound = false;
        foreach (string tag in UnityEditorInternal.InternalEditorUtility.tags)
        {
            if (tag == targetTag)
            {
                tagFound = true;
                break;
            }
        }
        if (!tagFound)
        {
            Debug.LogError("Player: " + targetTag + " not found for KillOnHit @ " + gameObject.name);
        }
#endif
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleHit(other.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        HandleHit(other.gameObject);
    }

    void HandleHit(GameObject other)
    {
        if (!other.CompareTag(targetTag)) return;

        // Instantiate visual effect
        if (effect != null)
        {
            GameObject expl = Instantiate(effect, other.transform.position, Quaternion.identity);
            Destroy(expl, 2f);
        }

        // Play sound
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Handle player-specific logic
        if (targetTag == "Player")
        {
            if (heartsScript == null)
                heartsScript = FindObjectOfType<Hearts>();

            if (heartsScript != null)
            {
                heartsScript.Lives--;

                if (heartsScript.Lives <= 0)
                {
                    Destroy(other, 0.1f); // Destroy player
                }
            }
        }
        else
        {
            Destroy(other, 0.1f); // Destroy other object (enemy, etc.)
        }

        Destroy(gameObject, 0.2f); // Destroy self (bullet, enemy, etc.)
    }
}
