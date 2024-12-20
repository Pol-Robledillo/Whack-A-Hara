using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioClip startGame;
    public AudioClip nextRound;
    private AudioSource audioSource;
    public int totalMoles, counter = 0, round = 0, correctMoles = 0;
    public float minWaitTime, maxWaitTime;
    public bool gamePaused = false;
    public GameObject pausePanel;
    public TextMeshProUGUI roundUI;
    public TextMeshProUGUI scoreUI;
    public Image moleTargetUI;
    private Color[,] colors = new Color[,]
    {
        {
        new Color(255f/255f, 0f/255f, 0f/255f, 1),
        new Color(0f/255f, 255f/255f, 0f/255f, 1),
        new Color(0f/255f, 0f/255f, 255f/255f, 1)
        },
        {
        new Color(242f/255f, 121f/255f, 49f/255f, 1),
        new Color(203f/255f, 157f/255f, 52f/255f, 1),
        new Color(158f/255f, 179f/255f, 45f/255f, 1)
        },
        {
        new Color(237f/255f, 158f/255f, 41f/255f, 1),
        new Color(192f/255f, 169f/255f, 37f/255f, 1),
        new Color(153f/255f, 172f/255f, 43f/255f, 1)
        },
        {
        new Color(37f/255f, 150f/255f, 190f/255f, 1),
        new Color(53f/255f, 162f/255f, 132f/255f, 1),
        new Color(35f/255f, 163f/255f, 67f/255f, 1)
        }
    };
    public GameObject[] moles;
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reiniciar el estado del juego cuando se recarga la escena
        ResetGame();
    }
    
    void Start()
    {
        Cursor.visible = false;

        audioSource = GetComponent<AudioSource>();

        // Obtener las referencias de la UI (asegurarte de que los objetos de la UI est�n asignados)
        if (roundUI == null) roundUI = GameObject.Find("Round").GetComponent<TextMeshProUGUI>();
        if (moleTargetUI == null) moleTargetUI = GameObject.Find("Target").GetComponent<Image>();
        if (scoreUI == null) scoreUI = GameObject.Find("Score").GetComponent<TextMeshProUGUI>(); // Asignar la puntuaci�n

        if (startGame != null)
        {
            audioSource.PlayOneShot(startGame);
        }

        // Inicializar el juego
        ResetGame();

        // Iniciar el ciclo de aparici�n de topos
        StartCoroutine(SpawnMoles());
    }

    // M�todo para reiniciar el juego
    void ResetGame()
    {
        round = 0;
        counter = 0;
        correctMoles = 0;

        roundUI.text = "" + (round + 1);
        moleTargetUI.color = colors[round, 0];
        scoreUI.text = "0";

        foreach (var mole in moles)
        {
            mole.GetComponent<Mole>().HideMole();
        }
    }

    IEnumerator SpawnMoles()
    {
        if (Mole.colorList == null || Mole.colorList[0] != colors[round, 0])
        {
            scoreUI.text = "0";
            Mole.colorList = new Color[] { colors[round, 0], colors[round, 1], colors[round, 2] };
            moleTargetUI.color = colors[round, 0];
            roundUI.text = "" + (round + 1);
        }

        while (counter < totalMoles)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

            GameObject mole;
            do
            {
                mole = moles[Random.Range(0, moles.Length)];
            } while (!mole.GetComponent<Mole>().isHidden);

            mole.GetComponent<Mole>().ShowMoleCorroutine = StartCoroutine(mole.GetComponent<Mole>().ShowMole());
            counter++;
        }

        yield return new WaitForSeconds(2f);

        round++;
        if (nextRound != null)
        {
            audioSource.PlayOneShot(nextRound);
        }

        counter = 0;
        if (round < 4)
        {
            yield return SpawnMoles();
        }
        else
        {
            Cursor.visible = true;
            SceneManager.LoadScene("Results");
        }
    }

    void Update()
    {
        DetectPause();
    }
    void DetectPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            TogglePause();
        }
    }
    void TogglePause()
    {
        
        gamePaused = !gamePaused;
        if ( !gamePaused)
        {
            Cursor.visible = false;
        }
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        pausePanel.SetActive(gamePaused);
    }
    public void ContinueButton()
    {
        Cursor.visible = false;
        TogglePause();
        Time.timeScale= 1f;
    }
    public void MenuButton()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;

    }
    public void ResetButton()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale= 1f;
    }


}