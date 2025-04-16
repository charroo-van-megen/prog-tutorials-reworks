using UnityEngine;

public class GetPickup : MonoBehaviour
{
    private Renderer r;
    private AudioSource source;
    private ParticleSystem ps;
    private KeepScore scoreScript;

    void Start()
    {
        // Pak alle componenten van dit object
        r = GetComponent<Renderer>();
        source = GetComponent<AudioSource>();
        ps = GetComponent<ParticleSystem>();
        ps.Stop(); // Zet particle systeem uit bij start

        // Zoek het score script ergens in de scene
        scoreScript = FindAnyObjectByType<KeepScore>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check of de speler de pickup raakt
        if (other.CompareTag("Player"))
        {
            r.enabled = false;           // Verberg de pickup
            source.Play();              // Speel geluid
            ps.Play();                  // Speel particles
            scoreScript.AddScore(5);    // Voeg 5 punten toe aan de score
            Destroy(gameObject, 0.5f);  // Verwijder pickup na 0.5 seconden
        }
    }
}
