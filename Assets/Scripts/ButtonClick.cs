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
    
    public GameObject[] player1Selection;
    public GameObject[] player2Selection;

    public GameObject playersData;

    public GameObject currentPlayerText;
    GameEngine gameEng = new GameEngine();
    void Start()
    {
        playersData = GameObject.Find("PlayersData");
        gameEng = this.gameObject.GetComponent<GameEngine>();
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
            player1Selection[0].transform.GetChild(0).gameObject.GetComponent<Text>().text = this.gameObject.GetComponent<GameEngine>().currentPlayer.playerNumSelected.tag;
            player1Selection[1].transform.GetChild(0).gameObject.GetComponent<Text>().text = this.gameObject.GetComponent<GameEngine>().currentPlayer.playerTypeSelected.tag;

            player1Selection[0].SetActive(true);
            player1Selection[1].SetActive(true);

            player1Selection[2].GetComponent<Button>().interactable = false;

            //Setting player values
            playersData.GetComponent<Players>().player1.playNum = numIndex;
            playersData.GetComponent<Players>().player1.playType = typeIndex;

            if (!player2Selection[0].activeSelf)
            {
                this.gameObject.GetComponent<GameEngine>().currentPlayer = playersData.GetComponent<Players>().player2;
                currentPlayerText.GetComponent<Text>().text = "Player 2";
            }

            else
            {
                SceneManager.LoadScene("Menu");
            }
        }
        else
        {
            player2Selection[0].transform.GetChild(0).gameObject.GetComponent<Text>().text = this.gameObject.GetComponent<GameEngine>().currentPlayer.playerNumSelected.tag;
            player2Selection[1].transform.GetChild(0).gameObject.GetComponent<Text>().text = this.gameObject.GetComponent<GameEngine>().currentPlayer.playerTypeSelected.tag;

            player2Selection[0].SetActive(true);
            player2Selection[1].SetActive(true);

            player2Selection[2].GetComponent<Button>().interactable = false;

            playersData.GetComponent<Players>().player2.playNum = numIndex;
            playersData.GetComponent<Players>().player2.playType = typeIndex;
            if (!player1Selection[0].activeSelf)
            {
                this.gameObject.GetComponent<GameEngine>().currentPlayer = playersData.GetComponent<Players>().player1;
                currentPlayerText.GetComponent<Text>().text = "Player 1";
            }
            else
            {
                SceneManager.LoadScene("CompareScene");
            }
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
        }
        else
        {
             this.gameObject.GetComponent<GameEngine>().currentPlayer =  playersData.GetComponent<Players>().player2;
             currentPlayerText.GetComponent<Text>().text = "Player 2";
        }
    }
}
