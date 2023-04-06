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
    public GameObject SpawnManager;
    
    private int score;
    private int highScore;
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

    void Update()
    {
        Death();
        Replay();
    }

    private void Death(){ 
        if(!Player.GetComponent<PlayerController>().playerIsAlive)
        {
            UpdateMaxScore();  
            Time.timeScale = 0f;    
        }
    }

    private void UpdateMaxScore()
    {
        int.TryParse(HighScoreText.text,out highScore);
        if(score>highScore){
            highScore = score;
        }
        HighScoreText.text = scoreText.text.PadLeft(5,'0');
        HighScoreLabel.alpha = 255;
        HighScoreText.alpha = 255;
    }

    private void Replay(){

    }
}
