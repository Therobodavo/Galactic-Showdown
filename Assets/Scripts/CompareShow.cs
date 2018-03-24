using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Inheriting from CompareResults to have access to methods
public class CompareShow : CompareResults
{
    //Variables
    public Players playerDat;
    public GameObject pd;
    public Text winText;
    public Text p1WinText;
    public Text p2WinText;
    
	// Use this for initialization
	void Start()
    {
        //Getting the players script to access data
        pd = GameObject.Find("PlayersData");

        //Setting player values from script
        //P1
        p1Num = pd.GetComponent<Players>().player1.playNum;
        p1Type = pd.GetComponent<Players>().player1.playType;

        //P2
        p2Num = pd.GetComponent<Players>().player2.playNum;
        p2Type = pd.GetComponent<Players>().player2.playType;

        //Running the method to see who won
        CompareInfo();

        //Checking the winner, and incrementing wins
        if (Winner == 1)
        {
            pd.GetComponent<Players>().player1.roundsWon++;
        }
        else if (Winner == 2)
        {
            pd.GetComponent<Players>().player2.roundsWon++;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

		//Checking the winner, and setting text accordingly
        if(Winner == 1)
        {
            winText.text = "Player 1 wins!";
        }
        else if (Winner == 2)
        {
            winText.text = "Player 2 wins!";
        }
        else
        {
            winText.text = "Neither player wins, it's a draw!";
        }

        //Displaying how many wins each player has
        p1WinText.text = "Player 1 wins: " + pd.GetComponent<Players>().player1.roundsWon;
        p2WinText.text = "Player 2 wins: " + pd.GetComponent<Players>().player2.roundsWon;
    }

    //Switching back to the main scene
    public void SwitchScene()
    {
        SceneManager.LoadScene("Main");
    }
}
