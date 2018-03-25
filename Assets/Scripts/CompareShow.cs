using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Inheriting from CompareResults to have access to methods
public class CompareShow : MonoBehaviour
{
    //Variables
    public GameObject pd;

    public Text winText;
    public Text p1WinText;
    public Text p2WinText;
    string winnerNum;
    string winnerType;
    
	// Use this for initialization
	void Start()
    {
        //Getting the players script to access data
        pd = GameObject.Find("PlayersData");

        //Gets the type and number winner
        winnerType= CompareType(pd.GetComponent<Players>().player1.typeSelected, pd.GetComponent<Players>().player2.typeSelected);      
        winnerNum = CompareNum(pd.GetComponent<Players>().player1.numSelected, pd.GetComponent<Players>().player2.numSelected, winnerType);

        //Debug shows the turn choices
        Debug.Log(pd.GetComponent<Players>().player1.typeSelected + " - " + pd.GetComponent<Players>().player1.numSelected);
        Debug.Log(pd.GetComponent<Players>().player2.typeSelected + " - " + pd.GetComponent<Players>().player2.numSelected);
        Debug.Log(winnerType);
        Debug.Log(winnerNum);

        //Checks who won
        if(pd.GetComponent<Players>().player1.numSelected == winnerNum && pd.GetComponent<Players>().player2.numSelected == winnerNum)
        {
            winText.text = "Neither player wins, it's a draw!";
        }
        else if(pd.GetComponent<Players>().player1.numSelected == winnerNum)
        {
            winText.text = "Player 1 wins!";
            pd.GetComponent<Players>().player1.roundsWon++;
        }
        else if(pd.GetComponent<Players>().player2.numSelected == winnerNum)
        {
            winText.text = "Player 2 wins!";
            pd.GetComponent<Players>().player2.roundsWon++;
        }

        //Displaying how many wins each player has
        p1WinText.text = "Player 1 wins: " + pd.GetComponent<Players>().player1.roundsWon;
        p2WinText.text = "Player 2 wins: " + pd.GetComponent<Players>().player2.roundsWon;
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    //Compares 2 types
    //1 beats 2, 2 beats 3, 3 beats 1
    private string CompareType(string type1, string type2)
    {
        //Default win result is type 1
        string result = type1;

        //Compares the 2 types
        switch(type1)
        {
            case "Type1":
                if(type2 == "Type3")
                {
                    result = type2;
                }
                break;
            case "Type2":
                if(type2 == "Type1")
                {
                    result = type2;
                }
                break;
            case "Type3":
                if(type2 == "Type2")
                {
                    result = type2;
                }
                break;
        }
        return result;
    }

    //Compares the 2 numbers
    private string CompareNum(string num1, string num2, string winType)
    {
        //Default win result is num1
        string winner = num1;

        //Stores int versions of num1 and num2
        int p1Num;
        int p2Num;

        //Converts strings to int
        int.TryParse(num1, out p1Num);
        int.TryParse(num2, out p2Num);

        //Highest number wins
        if (winType == "Type1")
        {
            if (p1Num < p2Num)
                winner = num2;
        }

        //Lowest Number wins
        if (winType == "Type2")
        {
            if (p1Num > p2Num)
                winner = num2;
        }

        //Number closest to 5 wins
        if (winType == "Type3")
        {
            if (Mathf.Abs(p1Num - 5) > Mathf.Abs(p2Num - 5))
                winner = num2;
         }
         return winner;
    }

    //Switching back to the main scene
    public void SwitchScene()
    {
        SceneManager.LoadScene("Main");
    }
}
