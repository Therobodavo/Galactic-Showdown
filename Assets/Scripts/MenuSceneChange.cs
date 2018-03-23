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

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ShowHelp()
    {
        mainPanel.SetActive(false);
        helpPanel.SetActive(true);
    }

    public void ShowMain()
    {
        mainPanel.SetActive(true);
        helpPanel.SetActive(false);
    }
}
