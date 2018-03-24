using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Inheriting from CompareResults to have access to methods
public class CompareShow : CompareResults
{
    //Variables
    public Players playerDat = new Players();
    public GameObject pd;
    public Text winText;
    public Text p1WinText;
    public Text p2WinText;
    
	// Use this for initialization
	void Start ()
    {
        //Debug.Log("Here");
        //Getting the players script to access data
        playerDat = GameObject.Find("PlayersData").GetComponent<Players>();
        pd = GameObject.Find("PlayersData");

        //Setting player values from script
        //P1
        //p1Num = playerDat.player1.playerNumSelected.GetComponent<objectValue>().value;
        //p1Num = pd.GetComponent<Players>().player1.playerNumSelected.GetComponent<objectValue>().value;

        p1Type = playerDat.player1.playerTypeSelected.GetComponent<objectValue>().value;

        //P2
        p2Num = playerDat.player2.playerNumSelected.GetComponent<objectValue>().value;
        p2Type = playerDat.player2.playerTypeSelected.GetComponent<objectValue>().value;

        //Running the method to see who won
        compareInfo();

        //Checking the winner, and incrementing wins
        if (Winner == 1)
        {
            playerDat.player1.intRoundsWon++;
        }
        else if (Winner == 2)
        {
            playerDat.player2.intRoundsWon++;
        }
        //Debug.Log("Here");
        //Debug.Log(p1Num + " " + p1Type);
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
        p1WinText.text = "Player 1 wins: " + playerDat.player1.intRoundsWon;
        p2WinText.text = "Player 2 wins: " + playerDat.player2.intRoundsWon;
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene("Main");
    }
}
