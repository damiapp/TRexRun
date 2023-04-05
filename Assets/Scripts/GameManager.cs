using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI HighScoreLabel;
    public GameObject Player;

    private int score;
    public int scoreIncreaseRate;
    public float speedIncrease;

    void Start()
    {
        score = 0;
        UpdateScoreText();
        StartCoroutine(IncreaseScore());
    }
    IEnumerator IncreaseScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f/speedIncrease);
            score += scoreIncreaseRate;
            UpdateScoreText();
        }
    }
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString().PadLeft(5,'0');
    }

}
