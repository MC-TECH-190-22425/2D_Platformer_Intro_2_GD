using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Create a reference for the Game Manager
    private GameManager gameManager;

    // Create a standard score for coins
    [SerializeField]
    int coinPoints = 100;

    // Do these actions when this item is awakened in the scene
    private void Awake()
    {
        // Assign the GameManger in this scene to the gameManager variable
        gameManager = FindObjectOfType<GameManager>(); 
    }

    // Do these actions when the trigger on this item is entered
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("The player is touching " + GetComponent<Collider2D>().tag);

        // Increase Coin counter
        gameManager.addCoin();

        // Increase Score
        gameManager.addScore(coinPoints);

        // Set Coin to inactive, visibly removing the item from the screen but not destroying it completely.
        gameObject.SetActive(false);
    }
}
