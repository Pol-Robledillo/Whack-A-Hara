using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject ConfigPanel;
    public GameObject ResultsPanel;
    private AudioSource audioSource;
    public AudioClip buttonSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void ClickAudio()
    {
        audioSource.Play();
    }
    public void StartButton()
    {
        SceneManager.LoadScene(""); //Añadir nombre de la escena
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
