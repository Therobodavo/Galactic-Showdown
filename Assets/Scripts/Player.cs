using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    //Number/Type button status. True = active, False = deactive
    public bool[] playerNumActive = new bool[9];
    public bool[] playerTypeActive = new bool[9];

    //Current selected Num and Type
    public GameObject playerTypeSelected = null;
    public GameObject playerNumSelected = null;

    //String saved from selection screen to comparison screen
    public string typeSelected = "";
    public string numSelected = "";

    //# of round wins for the player
    public int roundsWon = 0;

    //If the player hasn't locked in yet
    public bool allowInput;

    //Constructor
    public Player()
    {
        //Sets all types and numbers to true
        ResetHand();
    }

    public void ResetHand()
    {
        allowInput = true;

        //Sets all buttons and types to active
        for (int i = 0; i < playerNumActive.Length; i++)
        {
            playerNumActive[i] = true;
            playerTypeActive[i] = true;
        }
    }
}
