using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public GameObject selection;

    public void Deactivate() 
    {
        GameObject host = EventSystem.current.currentSelectedGameObject;
        selection.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = host.transform.GetChild(0).GetComponent<Text>().text;
        if(!selection.transform.GetChild(0).gameObject.activeSelf) 
        {
            selection.transform.GetChild(0).gameObject.SetActive(true);
        }
        host.GetComponent<Button>().interactable = false;
    }
    public void Disable() 
    {
        GameObject host = EventSystem.current.currentSelectedGameObject;
        selection.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = host.transform.GetChild(0).GetComponent<Text>().text;
        if(!selection.transform.GetChild(1).gameObject.activeSelf) 
        {
            selection.transform.GetChild(1).gameObject.SetActive(true);
        }
        host.SetActive(false);
    }
}
