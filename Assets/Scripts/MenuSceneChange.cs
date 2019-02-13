using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneChange : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    //Reference to each panel
    public GameObject mainPanel;
    public GameObject helpPanel;
    public GameObject creditsPanel; 

    //Run to change scene to sceneName
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    //Disable/Enable Objects for Help
    public void ShowHelp()
    {
        mainPanel.SetActive(false);
        helpPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    //Disable/Enable Objects for Main
    public void ShowMain()
    {
        mainPanel.SetActive(true);
        helpPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    //Disable/Enable Objects for Credits
    public void ShowCredits()
    {
        mainPanel.SetActive(false);
        helpPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
}
