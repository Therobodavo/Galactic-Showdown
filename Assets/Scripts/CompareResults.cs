using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareResults : MonoBehaviour {

    public GameObject playerTypeSelected = null;
    public GameObject playerNumSelected = null;

    //Player 1 attributes
    public int p1Type; // 1- highest, 2 lowest, 3 middle
    public int p1Num;
    
    //Player 2 attributes
    public int p2Type;
    public int p2Num;
    
    //Winning Type
    public int winType;
    
    //Winning Player
    public int Winner; // 1- player1 wins, 2- player2 wins, 3- Draw


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
        //compare will start once the play selects both type and num
        if(this.gameObject.GetComponent<GameEngine>().currentTurn.playerTypeSelected != null && this.gameObject.GetComponent<GameEngine>().currentTurn.playerNumSelected != null)
        {
            checkInfo();
            CompareInfo();
        }
        */
	}

    public void checkInfo()
    {
       //cheking what variables player 1 choose
       // playerTypeSelected = this.gameObject.GetComponent<GameEngine>().currentTurn.playerTypeSelected;
       // playerNumSelected = this.gameObject.GetComponent<GameEngine>().currentTurn.playerNumSelected;
        //storing chosen values
        p1Type = playerTypeSelected.GetComponent<objectValue>().value;
        p1Num = playerNumSelected.GetComponent<objectValue>().value;

    }
    public void CompareInfo()
    {
        //Type 1 wins
        if (p1Type + p2Type == 2 || p1Type + p2Type == 3) 
        {
            winType = 1;
        }

        //Type 2 wins
        if ((p1Type + p2Type == 4 && p1Type == 2) || p1Type + p2Type == 5) 
        {
            winType = 2;
        }

        //Type 3 wins
        if ((p1Type + p2Type == 4 && p1Type != 2) || p1Type + p2Type == 6) 
        {
            winType = 3;
        }

        //Highest number wins
        if (winType == 1)
        {
            if (p1Num > p2Num)
                Winner = 1;
            else if (p1Num < p2Num)
                Winner = 2;
            else if (p1Num == p2Num)
                Winner = 3;
        }

        //Lowest Number wins
        if (winType == 2)
        {
            if (p1Num > p2Num)
                Winner = 2;
            else if (p1Num < p2Num)
                Winner = 1;
            else if (p1Num == p2Num)
                Winner = 3;
        }

        //Number closest to 5 wins
        if (winType == 3)
        {
            if (Mathf.Abs(p1Num - 5) > Mathf.Abs(p2Num - 5))
                Winner = 2;
            else if (Mathf.Abs(p1Num - 5) < Mathf.Abs(p2Num - 5))
                Winner = 1;
            else if (Mathf.Abs(p1Num - 5) == Mathf.Abs(p2Num - 5))
                Winner = 3;
        }
    }
}
