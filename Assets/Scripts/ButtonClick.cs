using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Button Click Class
//Stores methods trigged by button clicks

public class ButtonClick : MonoBehaviour
{
    //Clears selected num and type
    private void ClearSelection() 
    {
        this.gameObject.GetComponent<GameEngine>().playerNumSelected = null;
        this.gameObject.GetComponent<GameEngine>().playerTypeSelected = null;
    }

    //Makes turn final, clears selected and updates active choices
    public void LockIn()
    {
        this.gameObject.GetComponent<GameEngine>().playerNumActive[this.gameObject.GetComponent<GameEngine>().playerNumSelected.transform.GetSiblingIndex() - 1] = false;
        this.gameObject.GetComponent<GameEngine>().playerTypeActive[this.gameObject.GetComponent<GameEngine>().playerTypeSelected.transform.GetSiblingIndex() - 1] = false;
        ClearSelection();
    }

    //Sets selected num to the one clicked
    public void SelectNum() 
    {
        this.gameObject.GetComponent<GameEngine>().playerNumSelected = EventSystem.current.currentSelectedGameObject;
        
    }

    //Sets selected type to the one clicked
    public void SelectType() 
    {
        this.gameObject.GetComponent<GameEngine>().playerTypeSelected = EventSystem.current.currentSelectedGameObject;
    }
}
