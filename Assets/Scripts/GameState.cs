using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {
    
    //Hold objects to use
    public GameObject[] text;

    //Reference to button for main menu
    public GameObject mainMenuBtn;

    //Reference to the players data
    GameObject playerData;

    //Timer variavles
    float timer;
    public  float timerDelay;

	// Use this for initialization
	void Start ()
    {
        //initialize variables
        timer = 0;
	    playerData = GameObject.Find("PlayersData");
        text[0].SetActive(false);
        text[1].SetActive(false);
        text[2].SetActive(false);
        mainMenuBtn.SetActive(false);

        //Check conditions (sudden death, game over state)
        if(playerData.GetComponent<Players>().startSuddenDeath)
        {
            text[2].SetActive(true);
            playerData.GetComponent<Players>().startSuddenDeath = false;
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
	void Update ()
    {

        //Checks sudden death state if the winner wasn't found
		if(playerData.GetComponent<Players>().suddenDeath && !playerData.GetComponent<Players>().foundWinner)
        {
            timer += 1 * Time.deltaTime;
            if(timer > timerDelay * Time.deltaTime)
            {
                SwitchScene("Main");
            }
        }

	}

    //Run to switch scenes
    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    //Restarts game;
    public void Reset()
    {
        Destroy(playerData);
        SceneManager.LoadScene("Menu");
    }
}
