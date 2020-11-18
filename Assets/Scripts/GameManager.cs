using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
