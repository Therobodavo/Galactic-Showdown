using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour {

    public Player player1;
    public Player player2;

    public static Players data;

    public bool suddenDeath;
    public bool startSuddenDeath;
    public bool foundWinner;
    public string playerWon;

	// Use this for initialization
    void Awake()
    {
        if(!data)
        {
            data = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        player1 = new Player();
        player2 = new Player();
        suddenDeath = false;
        startSuddenDeath = false;
        foundWinner = false;

    }
}
