using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    
    public GameObject[] text;
    public GameObject mainMenuBtn;
    GameObject playerData;
    
	// Use this for initialization
	void Start ()
    {
	    playerData = GameObject.Find("PlayersData");
        text[0].SetActive(false);
        text[1].SetActive(false);
        text[2].SetActive(false);
        mainMenuBtn.SetActive(false);
        if(playerData.GetComponent<Players>().startSuddenDeath)
        {
            text[2].SetActive(true);
            playerData.GetComponent<Players>().startSuddenDeath = false;

            //wait a few seconds

            //go back to main player scene
        }
        else if(playerData.GetComponent<Players>().foundWinner)
        {
            if(playerData.GetComponent<Players>().playerWon == "Player1")
            {
                text[0].SetActive(true);
            }
            else
            {
                text[1].SetActive(true);
            }
            mainMenuBtn.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
