using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject ConfigPanel;
    public GameObject ResultsPanel;
   

   
    public void StartButton()
    {
        SceneManager.LoadScene("Game"); //Añadir nombre de la escena
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void ConfigButton()
    {
        ConfigPanel.SetActive(true);
    }
    public void CloseButton()
    {
        ConfigPanel.SetActive(false);
        ResultsPanel.SetActive(false);
    }
    public void ResultsButton()
    {
        ResultsPanel.SetActive(true);
    }
}
