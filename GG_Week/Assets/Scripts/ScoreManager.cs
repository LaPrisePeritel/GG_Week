using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI deathScore;
    public TextMeshProUGUI beetleScoreText;
    private int score;
    public static int highScore;
    private bool newHighScore = false;
    private int beetleScore;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        highScoreText.text = highScore.ToString() + " meters";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString() + " meters";
        beetleScoreText.text = beetleScore.ToString();
    }

    public void ChangeScore(float playerScore)
    {
        score = (int)playerScore;
    }

    public void BeetleScore()
    {
        beetleScore++;
    }

    public void DeathScore()
    {
        if (score > highScore)
        {
            highScore = score;
            newHighScore = true;
        }
        if (newHighScore)
        {
            deathScore.text = "New Highscore " + score.ToString() + " meters";
            newHighScore = false;
        }
        else
        {
            deathScore.text = "You've covered " + score.ToString() + " meters";
        }
    }
}
