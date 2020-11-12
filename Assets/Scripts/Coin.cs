using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField]
    int coinPoints = 100;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();  // Assign the gameManger to the gameManager variable when this item awakens in a scene
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("The player is touching " + GetComponent<Collider2D>().tag);

        // Increase Coin counter
        gameManager.addCoin();

        // Increase Score
        gameManager.addScore(coinPoints);

        // Destroy Coin
        gameObject.SetActive(false);
    }
}
