using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }

    private int currentScore = 0;

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
    }

    public void AddPoints(int points)
    {
        currentScore += points;
        Debug.Log("Score: " + currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
        Debug.Log("Score reset.");
    }

    public int GetScore()
    {
        return currentScore;
    }
}
