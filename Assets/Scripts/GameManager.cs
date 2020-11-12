using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int lives = 3;

    [SerializeField]
    private int score;

    [SerializeField]
    private int coins;



    public int getLives()
    {
        return this.lives;
    }

    // 20201112

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
        lives++;
    }

    public void addCoin()
    {
        coins++;
        if (coins > 100)
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
