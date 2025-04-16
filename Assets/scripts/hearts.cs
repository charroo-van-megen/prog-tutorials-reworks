using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    private Image[] hearts;
    private int lives;
    private int maxLives;

    void Start()
    {
        Image[] images = GetComponentsInChildren<Image>();
        int count = 0;
        foreach (Image img in images)
        {
            if (img.name == "Heart") count++;
        }

        hearts = new Image[count];
        count = 0;

        foreach (Image img in images)
        {
            if (img.name == "Heart")
            {
                hearts[count] = img;
                count++;
            }
        }

        lives = hearts.Length;
        maxLives = hearts.Length;
    }

    public int Lives {
        get { return lives; }
        set {
            if (value <= maxLives && value >= 0) {
                lives = value;
                for (int i = 0; i < hearts.Length; i++) {
                    hearts[i].enabled = i < lives;
                }
                if (lives == 0) pauseGame();
            }
        }
    }

    void pauseGame()
    {
        Time.timeScale = 0f;
    }
}
