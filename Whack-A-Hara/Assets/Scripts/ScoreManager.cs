using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private TextMeshProUGUI scoreUI;
    private TextMeshProUGUI deut;
    private TextMeshProUGUI prot;
    private TextMeshProUGUI azulAmarillo;
    public int[] scores = new int[] { 0, 0, 0, 0 };
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
        try
        {

            deut = GameObject.Find("DeuteranomaliaR").GetComponent<TextMeshProUGUI>();
            prot = GameObject.Find("ProtanomaliaR").GetComponent<TextMeshProUGUI>();
            azulAmarillo = GameObject.Find("AzulR").GetComponent<TextMeshProUGUI>();
            /*int deutProb = scores[1] - scores[0];
            int protProb = scores[2] - scores[0];
            int azulAmarilloProb = scores[3] - scores[0];
            AssignResults(deut, deutProb);
            AssignResults(prot, protProb);
            AssignResults(azulAmarillo, azulAmarilloProb);*/
            AssignResults(deut, scores[1]);
            AssignResults(prot, scores[2]);
            AssignResults(azulAmarillo, scores[3]);

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
    public void AssignResults(TextMeshProUGUI text, int num)
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
}
