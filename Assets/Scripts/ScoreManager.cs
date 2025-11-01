using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]private TextMeshProUGUI scoreText;

    private int score = 0;

    private void Update()
    {
        DisplayScore();
    }

    private void OnEnable()
    {
        Obstacles.CheckCollider += AddScore;
    }

    private void OnDisable()
    {
        Obstacles.CheckCollider -= AddScore;
    }

    void AddScore(int value)
    {
        Debug.Log("Score added: " + value);
        score += value;
    }

    void DisplayScore()
    {
        if (scoreText != null) 
        {
            scoreText.text = "Score: " + score;
        }
    }
}
