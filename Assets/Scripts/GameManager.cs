using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int lives = 3;

    public int getLives(){
        return this.lives;
    }
}
