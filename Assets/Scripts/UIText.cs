using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIText : MonoBehaviour
{
    public Text livesText;
    private GameObject gameManager;
    private int lives;
    
    void Start()
    {
        gameManager = this.gameObject;
        lives = gameManager.GetComponent<GameManager>().getLives(); 
    }

    void Update()
    {
        lives = gameManager.GetComponent<GameManager>().getLives();
        livesText.text = "Lives = " + lives;
    }
}
