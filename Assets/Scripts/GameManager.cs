using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text GameOverText;
    public Text ScoreText;

    private int scoreValue = 0;

    void Start()
    {
        ScoreText.text = scoreValue.ToString();
        GameOverText.enabled = false;
    }


    public void AddScore(int valueToAdd)
    {
        scoreValue += valueToAdd;
        ScoreText.text = scoreValue.ToString();
    }

    public void GameOver()
    {
        GameOverText.enabled = true;
    }
}
