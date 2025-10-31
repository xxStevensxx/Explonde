using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private int score = 0;
    [SerializeField]private TextMeshProUGUI scoreText;

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
