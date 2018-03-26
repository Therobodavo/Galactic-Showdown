using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Game Engine Class
// Runs Start and Update to keep track of player data

public class GameEngine : MonoBehaviour {

    //Scene Objects
    public GameObject[] selector;
    public GameObject[] numbers;
    public GameObject[] types;
    public GameObject lockInBtn;

    public GameObject playersData;

    public GameObject userInput;
    public GameObject waitingText;

    public Player currentPlayer;

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
            if(waitingText.activeSelf)
            {
                waitingText.SetActive(false);
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
                selector[0].transform.GetChild(0).gameObject.GetComponent<Text>().text = currentPlayer.playerNumSelected.transform.GetChild(0).GetComponent<Text>().text;
                selector[0].SetActive(true);
            }
            else
            {
                selector[0].SetActive(false);
            }

            if(currentPlayer.playerTypeSelected != null) 
            {
                selector[1].transform.GetChild(0).gameObject.GetComponent<Text>().text = currentPlayer.playerTypeSelected.transform.GetChild(0).GetComponent<Text>().text;
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
        if(!currentPlayer.allowInput && !waitingText.activeSelf)
        {
            waitingText.SetActive(true);
        }
	}
}
