using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Game Engine Class
// Runs Start and Update to keep track of player data

public class GameEngine : MonoBehaviour {

    //Scene Objects
    public Sprite numImage;
    public GameObject[] selector;
    public GameObject[] numbers;
    public GameObject[] types;
    public GameObject lockInBtn;

    public GameObject playersData;

    public GameObject userInput;
    public GameObject waitingText;

    public Player currentPlayer;

    public Sprite[] typeImages;
    public Sprite[] numImages;



    public Text P1;
    public Text P2;

    void Start ()
    {
        playersData = GameObject.Find("PlayersData");
        playersData.GetComponent<Players>().player1.allowInput = true;
        playersData.GetComponent<Players>().player2.allowInput = true;
        currentPlayer = playersData.GetComponent<Players>().player1;

    }
	
	void Update ()
    {
        
        if(currentPlayer.allowInput)
        {
            if(!userInput.activeSelf)
            {
                userInput.SetActive(true);
            }
            //Shows states of numbers and types
		    for(int i = 0; i < currentPlayer.playerNumActive.Length; i++) 
            {
                if(!currentPlayer.playerNumActive[i] && numbers[i].activeSelf)
                {
                    numbers[i].GetComponent<Button>().interactable = false;   
                }
                else
                {
                    numbers[i].GetComponent<Button>().interactable = true;
                }
                if(!currentPlayer.playerTypeActive[i] && types[i].activeSelf) 
                {
                    types[i].GetComponent<Button>().interactable = false; 
                }
                else
                {
                    types[i].GetComponent<Button>().interactable = true;
                }
            }

            //Shows current selections
            if(currentPlayer.playerNumSelected != null)
            { 
                selector[0].GetComponent<Image>().sprite = currentPlayer.playerNumSelected.GetComponent<Image>().sprite;
                selector[0].SetActive(true);
            }
            else
            {
                selector[0].SetActive(false);
            }

            if(currentPlayer.playerTypeSelected != null) 
            {
                selector[1].GetComponent<Image>().sprite = currentPlayer.playerTypeSelected.GetComponent<Image>().sprite;
                selector[1].SetActive(true);
            }
            else
            {
                selector[1].SetActive(false);
            }

            //Shows state of lock in button
            if(currentPlayer.playerNumSelected == null || currentPlayer.playerTypeSelected == null)
            {
                lockInBtn.GetComponent<Button>().interactable = false;
            }
            else if(!lockInBtn.GetComponent<Button>().interactable)
            {
                lockInBtn.GetComponent<Button>().interactable = true;
            }
        }
        else if(userInput.activeSelf)
        {
            userInput.SetActive(false);
        }

        //Sets score text
        P1.text = "P1: " + playersData.GetComponent<Players>().player1.roundsWon;
        P2.text = "P2: " + playersData.GetComponent<Players>().player2.roundsWon;
    }

}
