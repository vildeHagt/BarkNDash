using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public GameOverScreen GameOverScreen;
    public bool isGameOver = false;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        GameOverScreen.Setup(Score.Instance.GetScore());
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
