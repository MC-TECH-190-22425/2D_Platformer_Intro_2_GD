using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.WSA;

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

    private void Awake()
    {
        // Check if this is the first run or if the game is over
        // either create 
        if (!PlayerPrefs.HasKey("lives"))
        {
            PlayerPrefs.SetInt("lives", lives);
        }
        else
        {
            lives = PlayerPrefs.GetInt("lives");
        }
        if (!PlayerPrefs.HasKey("score"))
        {
            PlayerPrefs.SetInt("score", 0);
        }
        else
        {
            score = PlayerPrefs.GetInt("score");
        }
        if (!PlayerPrefs.HasKey("lives"))
        {
            PlayerPrefs.SetInt("coins", 0);
        }
        else
        {
            coins = PlayerPrefs.GetInt("coins");
        }

        if (isGameOver || lives < 1)
        {
            lives = 3;
            coins = 0;
            score = 0;
            setGameOver(false);
        }
    }

    private void OnApplicationQuit()
    {
        // Removes All PlayerPrefs 
        PlayerPrefs.DeleteAll();
    }

    // Methods or Functions

    public void setGameOver(bool isGameOver)
    {
        this.isGameOver = isGameOver;
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

    public void removeLife()
    {
        lives--; // remove -1 from lives
        gameOverCheck();
        PlayerPrefs.SetInt("lives", lives);
    }

    public void addCoin()
    {
        coins++; // add +1 to coins
        PlayerPrefs.SetInt("coins", coins);

        if (coins > 99)
        {
            addLife(); // add an extra life
            PlayerPrefs.SetInt("lives", lives);
            coins = 0; // reset coins to zero
            PlayerPrefs.SetInt("coins", coins);
        }
    }

    public void addScore(int points)
    {
        score += points;
        PlayerPrefs.SetInt("score", score);
    }

    void gameOverCheck()
    {
        if (lives < 1)
        {
            Debug.Log("The Game is Over... Restarting Level");

            setGameOver(true);
            // then restart the scene
            SceneManager.LoadScene("SampleScene");

            
        } 
    }
}
