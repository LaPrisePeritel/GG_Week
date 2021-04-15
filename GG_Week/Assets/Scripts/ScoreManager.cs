using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI deathScore;
    public int score;
    public static int highScore;
    private bool newHighScore = false;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        highScoreText.text = "HighScore " + highScore.ToString() + " meters";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString() + " meters";
    }

    public void ChangeScore(float playerScore)
    {
        score = (int)playerScore;
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
