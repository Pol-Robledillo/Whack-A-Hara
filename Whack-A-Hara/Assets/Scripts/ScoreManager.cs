using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class ScoreManager : MonoBehaviour
{
    public GameManager gameManager;
    public static ScoreManager instance;
    private TextMeshProUGUI scoreUI;
    private TextMeshProUGUI deut;
    private TextMeshProUGUI prot;
    private TextMeshProUGUI azulAmarillo;
    public int[] scores = new int[] { 0, 0, 0, 0 };
    private string deuta;
    private string prota;
    private string azulAm;
    
    private void Awake()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        if (scoreUI == null)
        {
            scoreUI = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        }
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (gameManager == null)
            {
                gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            }
            StartCoroutine(InitializeUI());
            ResetScores();

        }
        try
        {
            deut = GameObject.Find("DeuteranomaliaR").GetComponent<TextMeshProUGUI>();
            prot = GameObject.Find("ProtanomaliaR").GetComponent<TextMeshProUGUI>();
            azulAmarillo = GameObject.Find("AzulR").GetComponent<TextMeshProUGUI>();

            AssignResults(deut, scores[1], "deuta");
            AssignResults(prot, scores[2], "prota");
            AssignResults(azulAmarillo, scores[3], "azulAm");

        }
        catch { Debug.Log("No se han encontrado"); }
    }
    public void UpdateScoreUI(int round)
    {
        Debug.Log(scoreUI);
        if (scoreUI != null)
        {
            scoreUI.text = "" + scores[round];
        }
    }
    public void AssignResults(TextMeshProUGUI text, int num, string result)
    {
        if (scores[0] == 0)
        {
            text.text = "No calculable";
        }
        else
        {
            if (num < (scores[0] / 3))
            {
                text.text = "Grave";
            }
            else if (num < (scores[0] / 3) * 2)
            {
                text.text = "Leve";
            }
            else
            {
                text.text = "No tienes";
            }
        }
        PlayerPrefs.SetString(result, text.text);
    }
    
    private void ResetScores()
    {
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = 0;
        }
        UpdateScoreUI(0);
    }
    private IEnumerator InitializeUI()
    {
        yield return null;  // Espera al siguiente frame

        // Ahora busca los objetos de la UI
        if (scoreUI == null)
        {
            scoreUI = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        }
        // Ahora actualiza la UI
        UpdateScoreUI(gameManager.GetComponent<GameManager>().round);
    }
    


}
