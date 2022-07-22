using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;

    void Start() 
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Score: 0";
    }

    public void IncreaseScore(int amountToIncrease)
    {
        score = score + amountToIncrease;
        scoreText.text = "Score:" + score.ToString();
    }
}
