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

    // Methods or Functions

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
    }

    public void removeLife()
    {
        lives--; // remove -1 from lives
        gameOverCheck();
    }

    public void addCoin()
    {
        coins++; // add +1 to coins

        if(coins > 99)
        {
            addLife(); // add an extra life
            coins = 0; // reset coins to zero
        }
    }

    public void addScore(int points)
    {
        score += points;
    }

    void gameOverCheck()
    {
        if (lives < 1)
        {
            Debug.Log("The Game is Over... Restarting Level");

            // then restart the scene
            SceneManager.LoadScene("SampleScene");
        } 
    }
}
