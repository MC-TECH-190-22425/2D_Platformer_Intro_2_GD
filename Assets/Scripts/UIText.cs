using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIText : MonoBehaviour
{

    private GameObject gameManager;
    private int lives;
    private int coins;
    private int score;

    public Text livesText;

    //20201112
    public Text scoreText;
    public Text coinsText;

    void Start()
    {
        gameManager = this.gameObject;
        lives = gameManager.GetComponent<GameManager>().getLives();
        coins = gameManager.GetComponent<GameManager>().getCoins();
        score = gameManager.GetComponent<GameManager>().getCoins();
    }

    void Update()
    {
        lives = gameManager.GetComponent<GameManager>().getLives();
        livesText.text = "Lives = " + lives;

        coins = gameManager.GetComponent<GameManager>().getCoins();
        coinsText.text = "Coins = " + coins;

        score = gameManager.GetComponent<GameManager>().getScore();
        scoreText.text = "Score = " + score;


    }
}
