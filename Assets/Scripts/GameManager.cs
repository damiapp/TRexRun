using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public GameObject ScoreBoard;
    public GameObject Player;
    public GameObject PlayAgain;
    public GameObject groundObject;
    public DayChangeManager dayChangeManager;
    public SpawnManager spawnManager;
    public PlayerData PlayerData;
    public SoundManager SoundManager;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighScoreText;

    private int score;
    private int highScore;
    private int scoreIncreaseRate;
    private float speedIncrease;
    private const string ORIGINAL_GAME = "OriginalGame";
    private const string UPGRADED_GAME = "UpgradedGame";

    private void Awake()
    {
        PlayerData.SetSpeed();
        if (PlayerData.highScore > 0) 
        { 
            highScore = PlayerData.highScore;
            UpdateHighScore();
        }
        else
        {
            highScore = 0;
        }
    }

    void Start()
    {
        scoreIncreaseRate = 1;
        speedIncrease = 1;
        score = 0;
        UpdateScoreText();
        StartCoroutine(IncreaseScore());
    }

    void Update()
    {
        
        Death();
    }

    IEnumerator IncreaseScore()
    {
        while (true)
        {   
            yield return new WaitForSeconds(0.05f/speedIncrease);
            if (score % 100 == 0 && score!=0)
            {
                ScoreBoard.GetComponent<Animator>().SetTrigger("Flash");
                SoundManager.PlayCheckPointSound();
                if (score % 400 == 0)
                {
                    PlayerData.speed += speedIncrease;
                    spawnManager.maxSpawnDelay -= 1/PlayerData.speed;
                    spawnManager.minSpawnDelay -= 1/PlayerData.speed;
                }
                yield return new WaitForSeconds(1);
            }
            score += scoreIncreaseRate;
            if(score == 700){
                dayChangeManager.ChangeDayToNight();
            } 
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


    private void Death(){ 
        if(!Player.GetComponent<PlayerController>().playerIsAlive)
        {
            UpdateHighScore();  
            Time.timeScale = 0f;
            PlayAgain.SetActive(true);
            Replay();
        }
    }

    private void UpdateHighScore()
    {
        if(score>highScore){
            highScore = score;
            PlayerData.highScore = score;
        }
        HighScoreText.text = "HI "+ highScore.ToString().PadLeft(5,'0');
        HighScoreText.alpha = 255;
    }

    private void Replay(){
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) {
            Time.timeScale = 1f;
            if(SceneManager.GetActiveScene().name == ORIGINAL_GAME)
                SceneManager.LoadScene(ORIGINAL_GAME);
            else if(SceneManager.GetActiveScene().name == UPGRADED_GAME)
                SceneManager.LoadScene(UPGRADED_GAME);
        }
    }

    private void OnDisable()
    {
        PlayerData.speed = 0f;
    }
}
