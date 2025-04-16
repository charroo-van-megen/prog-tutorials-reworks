using TMPro;
using UnityEngine;

public class KeepScore : MonoBehaviour
{
    private TMP_Text scoreField;
    private int score = 0;

    void Start()
    {
        scoreField = GetComponent<TMP_Text>();  // Koppel het tekstveld
        scoreField.text = "Score: " + score;    // Start op 0
    }

    // Methode die andere scripts kunnen aanroepen
    public void AddScore(int add)
    {
        score += add;
        scoreField.text = "Score: " + score;    // Update de tekst
    }
}
