using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Create a reference for the Game Manager
    private GameManager gameManager;

    // Create a standard score for coins
    [SerializeField]
    private int coinPoints = 100;

    // Do some Action(s) when the item that this script is on is awakened in the scene
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Do some Action when the trigger on this item is entered
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Coin says it was touched by a coin
        Debug.Log("This coin was touched by " + collision.tag);

        //Check for player tag
        if (collision.CompareTag("Player"))
        {
            // Increase Coin Counter
            gameManager.addCoin();

            // Increase Score
            gameManager.addScore(coinPoints);

            // Set this Coin to inactive, visibly removes the object from the scene without destroying it.
            gameObject.SetActive(false);
        }
        

    }

}
