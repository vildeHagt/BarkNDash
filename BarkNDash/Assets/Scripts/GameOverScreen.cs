using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = "SCORE: " + score;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("BarkNDashScene");
    }
}
