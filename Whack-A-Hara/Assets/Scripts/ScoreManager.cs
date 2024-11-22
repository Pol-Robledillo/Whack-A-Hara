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
    public int[] scores = new int[] { 0, 0, 0, 0 };
    private void Awake()
    {
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
    public void UpdateScoreUI(int round)
    {
        Debug.Log(scoreUI);
        if (scoreUI != null)
        {
            scoreUI.text = "" + scores[round];
        }
    }
}
