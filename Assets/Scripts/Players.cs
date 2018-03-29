using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour {

    //The 2 player objects
    public Player player1;
    public Player player2;

    //Singleton
    public static Players data;

    //If sudden death is active
    public bool suddenDeath;

    //Variable to check if sudden death just started
    public bool startSuddenDeath;

    //If a winner has been found
    public bool foundWinner;

    //The player name of who won the overall game
    public string playerWon;

	// Use this for initialization
    void Awake()
    {
        //Singleton stuff
        if(!data)
        {
            data = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        //Sets up both player objects
        player1 = new Player();
        player2 = new Player();

        //Sets everything to false
        suddenDeath = false;
        startSuddenDeath = false;
        foundWinner = false;

    }
}
