using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }

    private int currentScore = 0;
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void AddPoints(int points)
    {
        currentScore += points;
        scoreText.text = "Score: " + currentScore;
    }

    public void DestroyScore()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    public int GetScore()
    {
        return currentScore;
    }
}
