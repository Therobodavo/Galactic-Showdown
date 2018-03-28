using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneChange : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    public GameObject mainPanel;

    public GameObject helpPanel;

    public GameObject creditsPanel; 

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ShowHelp()
    {
        mainPanel.SetActive(false);
        helpPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void ShowMain()
    {
        mainPanel.SetActive(true);
        helpPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void ShowCredits()
    {
        mainPanel.SetActive(false);
        helpPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
}
