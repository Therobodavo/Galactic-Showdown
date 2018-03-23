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
        string name = this.gameObject.GetComponent<GameEngine>().playerNumSelected.name;
        name = name.Remove(0, 3);
        int index = 0;
        int.TryParse(name, out index);
        this.gameObject.GetComponent<GameEngine>().playerNumActive[index] = false;

        name = this.gameObject.GetComponent<GameEngine>().playerTypeSelected.name;
        name = name.Remove(0, 4);
        int.TryParse(name, out index);
        this.gameObject.GetComponent<GameEngine>().playerTypeActive[index] = false;
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
