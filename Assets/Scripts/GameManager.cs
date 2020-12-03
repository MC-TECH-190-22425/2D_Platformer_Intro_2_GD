using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables
    [SerializeField]
    private int lives = 3;

    [SerializeField]
    private int score;

    [SerializeField]
    private int coins;

    [SerializeField]
    private bool isGameOver = false;

    // Methods or Functions

    private void Awake()
    {
        // Check if this is the first run and either create the PlayerPrefs
        // or Set the UI to the existing PlayerPref

        // Lives
        if (!PlayerPrefs.HasKey("lives"))
        {
            PlayerPrefs.SetInt("lives", lives);
        }
        else
        {
            lives = PlayerPrefs.GetInt("lives");
        }

        // Score
        if (!PlayerPrefs.HasKey("score"))
        {
            PlayerPrefs.SetInt("score", score);
        }
        else
        {
            score = PlayerPrefs.GetInt("score");
        }

        // Coins
        if (!PlayerPrefs.HasKey("coins"))
        {
            PlayerPrefs.SetInt("coins", coins);
        }
        else
        {
            coins = PlayerPrefs.GetInt("coins");
        }

        // if the Game is Over or lives are below on on Awake
        // reset our variables.

    }

    private void Update()
    {
        if (isGameOver)
        {
            lives = 3;
            PlayerPrefs.SetInt("lives", lives);
            coins = 0;
            PlayerPrefs.SetInt("coins", coins);
            score = 0;
            PlayerPrefs.SetInt("score", score);
            isGameOver = false;
        }
    }

    public int getLives()
    {
        return this.lives;
    }

    public int getScore()
    {
        return this.score;
    }

    public int getCoins()
    {
        return this.coins;
    }

    public void addLife()
    {
        lives++;  // add +1 to lives
        PlayerPrefs.SetInt("lives", lives);
    }

    public void addCoin()
    {
        coins++; // add +1 to coins
        PlayerPrefs.SetInt("coins", coins);

        if (coins > 99)
        {
            addLife(); // add an extra life
            coins = 0; // reset coins to zero
            PlayerPrefs.SetInt("coins", coins);
        }
    }

    public void addScore(int points)
    {
        score += points;
        PlayerPrefs.SetInt("score", score);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

    void gameOverCheck()
    {
        if (lives < 1)
        {
            Debug.Log("The Game is Over... Restarting Level");

            SceneManager.LoadScene("SampleScene");
            isGameOver = true;
        }
    }

    public void removeLife()
    {
        lives--;
        PlayerPrefs.SetInt("lives", lives);
        gameOverCheck();
    }
}
