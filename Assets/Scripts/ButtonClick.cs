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
    
    void Start()
    {
        playersData = GameObject.Find("PlayersData");
    }
    //Clears selected num and type
    private void ClearSelection() 
    {
        this.gameObject.GetComponent<GameEngine>().currentTurn.playerNumSelected = null;
        this.gameObject.GetComponent<GameEngine>().currentTurn.playerTypeSelected = null;
    }

    //Makes turn final, clears selected and updates active choices
    public void LockIn()
    {
        string name = this.gameObject.GetComponent<GameEngine>().currentTurn.playerNumSelected.name;
        name = name.Remove(0, 3);
        int index = 0;
        int.TryParse(name, out index);
        this.gameObject.GetComponent<GameEngine>().currentTurn.playerNumActive[index] = false;

        name = this.gameObject.GetComponent<GameEngine>().currentTurn.playerTypeSelected.name;
        name = name.Remove(0, 4);
        int.TryParse(name, out index);
        this.gameObject.GetComponent<GameEngine>().currentTurn.playerTypeActive[index] = false;

        //Sets player selection display
        if(this.gameObject.GetComponent<GameEngine>().currentTurn == playersData.GetComponent<Players>().player1)
        {
            player1Selection[0].transform.GetChild(0).gameObject.GetComponent<Text>().text = this.gameObject.GetComponent<GameEngine>().currentTurn.playerNumSelected.tag;
            player1Selection[1].transform.GetChild(0).gameObject.GetComponent<Text>().text = this.gameObject.GetComponent<GameEngine>().currentTurn.playerTypeSelected.tag;

            player1Selection[0].SetActive(true);
            player1Selection[1].SetActive(true);

            player1Selection[2].GetComponent<Button>().interactable = false;

            if (!player2Selection[0].activeSelf)
            {
                this.gameObject.GetComponent<GameEngine>().currentTurn = playersData.GetComponent<Players>().player2;
                currentPlayerText.GetComponent<Text>().text = "Player 2";
            }

            else
            {
                SceneManager.LoadScene("Menu");
            }
        }
        else
        {
            player2Selection[0].transform.GetChild(0).gameObject.GetComponent<Text>().text = this.gameObject.GetComponent<GameEngine>().currentTurn.playerNumSelected.tag;
            player2Selection[1].transform.GetChild(0).gameObject.GetComponent<Text>().text = this.gameObject.GetComponent<GameEngine>().currentTurn.playerTypeSelected.tag;
            player2Selection[0].SetActive(true);
            player2Selection[1].SetActive(true);
            player2Selection[2].GetComponent<Button>().interactable = false;
            if(!player1Selection[0].activeSelf)
            {
                this.gameObject.GetComponent<GameEngine>().currentTurn = playersData.GetComponent<Players>().player1;
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
        this.gameObject.GetComponent<GameEngine>().currentTurn.playerNumSelected = EventSystem.current.currentSelectedGameObject;
        
    }

    //Sets selected type to the one clicked
    public void SelectType() 
    {
        this.gameObject.GetComponent<GameEngine>().currentTurn.playerTypeSelected = EventSystem.current.currentSelectedGameObject;
    }
    public void SetTurn(int num) 
    {
        if(num == 1)
        {
             this.gameObject.GetComponent<GameEngine>().currentTurn = playersData.GetComponent<Players>().player1;
             currentPlayerText.GetComponent<Text>().text = "Player 1";
        }
        else
        {
             this.gameObject.GetComponent<GameEngine>().currentTurn =  playersData.GetComponent<Players>().player2;
             currentPlayerText.GetComponent<Text>().text = "Player 2";
        }
    }
}
