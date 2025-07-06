using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public GameOverScreen GameOverScreen;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void GameOver()
    {
        GameOverScreen.Setup(Score.Instance.GetScore());
    }
}
