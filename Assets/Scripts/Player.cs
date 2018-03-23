﻿using System.Collections;
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

    public int intRoundsWon = 0;

    public Player()
    {
        //Sets all buttons and types to active
		for(int i = 0; i < playerNumActive.Length; i++) 
        {
            playerNumActive[i] = true;
            playerTypeActive[i] = true;
        }
    }
}