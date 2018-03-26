using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Button Click Class
//Stores methods trigged by button clicks

public class ButtonClick : MonoBehaviour
{
    //Switching Players buttons
    public GameObject player1Btn;
    public GameObject player2Btn;

    public GameObject playersData;

    public GameObject currentPlayerText;

    public GameObject userInput;
    void Start()
    {
        playersData = GameObject.Find("PlayersData");
    }
    //Clears selected num and type
    private void ClearSelection() 
    {
        this.gameObject.GetComponent<GameEngine>().currentPlayer.playerNumSelected = null;
        this.gameObject.GetComponent<GameEngine>().currentPlayer.playerTypeSelected = null;
    }

    //Makes turn final, clears selected and updates active choices
    public void LockIn()
    {
        string name = this.gameObject.GetComponent<GameEngine>().currentPlayer.playerNumSelected.name;
        name = name.Remove(0, 3);
        int numIndex = 0;
        int.TryParse(name, out numIndex);
        this.gameObject.GetComponent<GameEngine>().currentPlayer.playerNumActive[numIndex] = false;


        name = this.gameObject.GetComponent<GameEngine>().currentPlayer.playerTypeSelected.name;
        name = name.Remove(0, 4);
        int typeIndex = 0;
        int.TryParse(name, out typeIndex);
        this.gameObject.GetComponent<GameEngine>().currentPlayer.playerTypeActive[typeIndex] = false;

        //Sets player selection display
        if(this.gameObject.GetComponent<GameEngine>().currentPlayer == playersData.GetComponent<Players>().player1)
        {

            playersData.GetComponent<Players>().player1.typeSelected = this.gameObject.GetComponent<GameEngine>().currentPlayer.playerTypeSelected.tag;
            playersData.GetComponent<Players>().player1.numSelected = this.gameObject.GetComponent<GameEngine>().currentPlayer.playerNumSelected.tag;

            //Disable input
            playersData.GetComponent<Players>().player1.allowInput = false;

            //Set waiting text
        }
        else
        {
            playersData.GetComponent<Players>().player2.typeSelected = this.gameObject.GetComponent<GameEngine>().currentPlayer.playerTypeSelected.tag;
            playersData.GetComponent<Players>().player2.numSelected = this.gameObject.GetComponent<GameEngine>().currentPlayer.playerNumSelected.tag;

            //Disable input
            playersData.GetComponent<Players>().player2.allowInput = false;

            //Set waiting text
        }
        if(!playersData.GetComponent<Players>().player1.allowInput && !playersData.GetComponent<Players>().player2.allowInput)
        {
                SceneManager.LoadScene("CompareScene");
        }
        ClearSelection();
    }

    //Sets selected num to the one clicked
    public void SelectNum() 
    {
        this.gameObject.GetComponent<GameEngine>().currentPlayer.playerNumSelected = EventSystem.current.currentSelectedGameObject;
        
    }

    //Sets selected type to the one clicked
    public void SelectType() 
    {
        this.gameObject.GetComponent<GameEngine>().currentPlayer.playerTypeSelected = EventSystem.current.currentSelectedGameObject;
    }
    public void SetTurn(int num) 
    {
        if(num == 1)
        {
             this.gameObject.GetComponent<GameEngine>().currentPlayer = playersData.GetComponent<Players>().player1;
             currentPlayerText.GetComponent<Text>().text = "Player 1";

             player1Btn.SetActive(false);
             player2Btn.SetActive(true);
        }
        else
        {
             this.gameObject.GetComponent<GameEngine>().currentPlayer =  playersData.GetComponent<Players>().player2;
             currentPlayerText.GetComponent<Text>().text = "Player 2";

             player2Btn.SetActive(false);
             player1Btn.SetActive(true);
        }
    }
}
