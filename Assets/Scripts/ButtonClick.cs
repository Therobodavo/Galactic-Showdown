using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public GameObject selection;
    GameObject selectedNum;
    GameObject selectedType;
    private void Deactivate() 
    {
        selectedNum.GetComponent<Button>().interactable = false;
    }
    private void Disable() 
    {
        selectedType.SetActive(false);
    }
    private void ClearSelection() 
    {
        selection.transform.GetChild(1).gameObject.SetActive(false);
        selection.transform.GetChild(2).gameObject.SetActive(false);
    }
    public void LockIn()
    {
        Deactivate();
        Disable();
        ClearSelection();
    }
    public void SelectNum() 
    {
        selectedNum = EventSystem.current.currentSelectedGameObject;
        selection.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = selectedNum.transform.GetChild(0).GetComponent<Text>().text;
        if(!selection.transform.GetChild(1).gameObject.activeSelf) 
        {
            selection.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public void SelectType() 
    {
        selectedType = EventSystem.current.currentSelectedGameObject;
        selection.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = selectedType.transform.GetChild(0).GetComponent<Text>().text;
        if(!selection.transform.GetChild(2).gameObject.activeSelf) 
        {
            selection.transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}
