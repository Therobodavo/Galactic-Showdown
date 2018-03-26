using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Linq;


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

    float timer;
   public  float timerDelay;
    float stage;
    float Winner; // 1- player1, 2- player 2, 3- tie

    public Sprite[] NumSprites;
    public Sprite[] TypeSprites;
  public   GameObject P1;
  public  GameObject P2;
    GameObject Win;

    // Use this for initialization
    void Start()
    {
        timer = 0;
        stage = 0;

        //Getting the players script to access data
        pd = GameObject.Find("PlayersData");


        //accessing player game objects
        P1 = GameObject.FindGameObjectWithTag("P1");
        P1.SetActive(false);
        P2 = GameObject.FindGameObjectWithTag("P2");
        P2.SetActive(false);
        Win = GameObject.FindGameObjectWithTag("Winner");
        Win.SetActive(false);

        //Gets the type and number winner
        winnerType = CompareType(pd.GetComponent<Players>().player1.typeSelected, pd.GetComponent<Players>().player2.typeSelected);      
        winnerNum = CompareNum(pd.GetComponent<Players>().player1.numSelected, pd.GetComponent<Players>().player2.numSelected, winnerType);

        //Debug shows the turn choices
        Debug.Log(pd.GetComponent<Players>().player1.typeSelected + " - " + pd.GetComponent<Players>().player1.numSelected);
        Debug.Log(pd.GetComponent<Players>().player2.typeSelected + " - " + pd.GetComponent<Players>().player2.numSelected);
        Debug.Log(winnerType);
        Debug.Log(winnerNum);

        //Checks who won
        if(pd.GetComponent<Players>().player1.numSelected == winnerNum && pd.GetComponent<Players>().player2.numSelected == winnerNum)
        {
            Winner = 3;
          //  winText.text = "Neither player wins, it's a draw!";
        }
        else if(pd.GetComponent<Players>().player1.numSelected == winnerNum)
        {
            Winner = 1;
           // winText.text = "Player 1 wins!";
            pd.GetComponent<Players>().player1.roundsWon++;
        }
        else if(pd.GetComponent<Players>().player2.numSelected == winnerNum)
        {
            Winner = 2;
           // winText.text = "Player 2 wins!";
            pd.GetComponent<Players>().player2.roundsWon++;
        }

      
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(timer > timerDelay * Time.deltaTime)
        {
            timer = 0;
            stage++;
        }

        if(stage == 0)
        {
            winText.text = "Player Actions";
            timer+= 1 * Time.deltaTime;
        }
        if (stage == 1)
        {
            P1.SetActive(true);
            P1.GetComponent<SpriteRenderer>().sprite = TypeSprites[CheckValue(pd.GetComponent<Players>().player1.typeSelected)];
            timer += 2 * Time.deltaTime;
        }
        if (stage == 2)
        {
            P2.SetActive(true);
            P2.GetComponent<SpriteRenderer>().sprite = TypeSprites[CheckValue(pd.GetComponent<Players>().player2.typeSelected)];
            timer += 2 * Time.deltaTime;
        }
        if (stage == 3)
        {
            P1.SetActive(false);
            P2.SetActive(false);
            winText.text = "Winning Action";
            Win.SetActive(true);
            Win.GetComponent<SpriteRenderer>().sprite = TypeSprites[CheckValue(winnerType)];
            timer += 1 * Time.deltaTime;
        }
        if (stage == 4)
        {
            winText.text = "Number of Ships Sent";
            timer += 2 * Time.deltaTime;
        }
        if (stage == 5)
        {
            P1.SetActive(true);
            P1.GetComponent<SpriteRenderer>().sprite = NumSprites[Int32.Parse((pd.GetComponent<Players>().player1.numSelected)) - 1];
            timer += 2 * Time.deltaTime;
        }
        if (stage == 6)
        {
            P2.SetActive(true);
            P2.GetComponent<SpriteRenderer>().sprite = NumSprites[Int32.Parse((pd.GetComponent<Players>().player2.numSelected)) - 1];
            timer += 2 * Time.deltaTime;
        }
        if (stage == 7)
        {
            P1.SetActive(false);
            P2.SetActive(false);
            Win.SetActive(false);

            if (Winner == 1)
                winText.text = "Player 1 Wins!!!";
            if (Winner == 2)
                winText.text = "Player 2 Wins!!!";
            if (Winner == 3)
                winText.text = "Neither player wins, it's a draw!";

            //Displaying how many wins each player has
            p1WinText.text = "Player 1 wins: " + pd.GetComponent<Players>().player1.roundsWon;
            p2WinText.text = "Player 2 wins: " + pd.GetComponent<Players>().player2.roundsWon;
            timer += 1 * Time.deltaTime;

        }
        if(stage == 8)
        {
            SwitchScene();
        }
        
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
    int CheckValue(string Type)
    {
        if (Type == "Type1")
            return 0;
       else if (Type == "Type2")
            return 1;
        else 
            return 2;

    }
    //Switching back to the main scene
    public void SwitchScene()
    {
        SceneManager.LoadScene("Main");
    }
}
