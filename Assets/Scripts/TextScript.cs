using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI preScreenText; 

    int highScore = 0;
    private int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        Enemy.OnEnemyDied += EnemyOnEnemyDied;
        EnemySpawner.OnGameStarted += OnGameStarted;
        EnemySpawner.OnGameEnded += OnGameEnded;
    }

    void OnGameStarted()
    {
        preScreenText.text = "";
        scoreText.text = $"Score         Hi-Score\n 0000         {PlayerPrefs.GetInt("HighScore",0).ToString("0000")}";
    }
    void EnemyOnEnemyDied(int pointsWorth)
    {
        Debug.Log($"I got one! It was worth ${pointsWorth}!");
        currentScore += pointsWorth;
        CheckHighScore();
        scoreText.text = $"Score         Hi-Score\n{currentScore.ToString("0000")}         {PlayerPrefs.GetInt("HighScore",0).ToString("0000")}";
    }

    void CheckHighScore() 
    {
        if(currentScore > PlayerPrefs.GetInt("HighScore",0)) 
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        
        }
    }

    void OnGameEnded()
    {
        Debug.Log("Game Over! This is in TextScript.cs!");
        scoreText.text = $"Score         Hi-Score\n{currentScore.ToString("0000")}         {PlayerPrefs.GetInt("HighScore",0).ToString("0000")}              Game Over! Press Enter to play again!";
        if(currentScore > PlayerPrefs.GetInt("HighScore",0)) 
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        
        }
        currentScore = 0;
    }
}
