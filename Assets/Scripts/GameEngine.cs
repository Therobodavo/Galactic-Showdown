using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Game Engine Class
// Runs Start and Update to keep track of player data

public class GameEngine : MonoBehaviour {
    
    //Number/Type button status. True = active, False = deactive
    public bool[] playerNumActive = new bool[9];
    public bool[] playerTypeActive = new bool[9];

    //Current selected Num and Type
    public GameObject playerTypeSelected = null;
    public GameObject playerNumSelected = null;

    //Scene Objects
    public GameObject selector;
    public GameObject numbers;
    public GameObject types;
    public GameObject lockInBtn;

	void Start ()
    {
        //Sets all buttons and types to active
		for(int i = 0; i < playerNumActive.Length; i++) 
        {
            playerNumActive[i] = true;
            playerTypeActive[i] = true;
        }
	}
	
	void Update ()
    {
        //Shows states of numbers and types
		for(int i = 0; i < playerNumActive.Length; i++) 
        {
            if(!playerNumActive[i] && numbers.transform.GetChild(i).gameObject.activeSelf)
            {
                numbers.transform.GetChild(i + 1).gameObject.GetComponent<Button>().interactable = false;   
            }
            if(!playerTypeActive[i] && types.transform.GetChild(i).gameObject.activeSelf) 
            {
                types.transform.GetChild(i + 1).gameObject.SetActive(false);  
            }
        }

        //Shows current selections
        if(playerNumSelected != null)
        {
            selector.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = playerNumSelected.transform.GetChild(0).GetComponent<Text>().text;
            selector.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            selector.transform.GetChild(1).gameObject.SetActive(false);
        }

        if(playerTypeSelected != null) 
        {
            selector.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = playerTypeSelected.transform.GetChild(0).GetComponent<Text>().text;
            selector.transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            selector.transform.GetChild(2).gameObject.SetActive(false);
        }

        //Shows state of lock in button
        if(playerNumSelected == null || playerTypeSelected == null)
        {
            lockInBtn.GetComponent<Button>().interactable = false;
        }
        else if(!lockInBtn.GetComponent<Button>().interactable)
        {
            lockInBtn.GetComponent<Button>().interactable = true;
        }
	}
}
