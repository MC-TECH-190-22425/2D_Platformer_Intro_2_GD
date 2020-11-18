using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIText : MonoBehaviour
{
    public Text livesText;
    public Text scoreText;
    public Text coinsText;

    private GameObject gameManager;
    private int lives;
    private int coins;
    private int score;
    
    void Start()
    {
        gameManager = this.gameObject;
        lives = gameManager.GetComponent<GameManager>().getLives();
        score = gameManager.GetComponent<GameManager>().getScore();
        coins = gameManager.GetComponent<GameManager>().getCoins();
    }

    void Update()
    {
        lives = gameManager.GetComponent<GameManager>().getLives();
        livesText.text = "Lives = " + lives;

        score = gameManager.GetComponent<GameManager>().getScore();
        scoreText.text = "Score = " + score;

        coins = gameManager.GetComponent<GameManager>().getCoins();
        coinsText.text = "Coins = " + coins;
    }
}
