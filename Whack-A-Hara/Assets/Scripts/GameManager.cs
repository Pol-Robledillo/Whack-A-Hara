using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalMoles, counter = 0, round = 0;
    public float minWaitTime, maxWaitTime;
    public bool gamePaused = false;
    public GameObject pausePanel;
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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMoles());
    }
    IEnumerator SpawnMoles()
    {
        if (Mole.colorList == null || Mole.colorList[0] != colors[round, 0])
        {
            Mole.colorList = new Color[] { colors[round, 0], colors[round, 1], colors[round, 2] };
        }
        while(counter<totalMoles)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            GameObject mole;
            do
            {
                mole = moles[Random.Range(0, moles.Length - 1)];
            } while (!mole.GetComponent<Mole>().isHidden);
            mole.GetComponent<Mole>().ShowMoleCorroutine = StartCoroutine(mole.GetComponent<Mole>().ShowMole());
            counter++;
            yield return SpawnMoles();
        }
        round++;
        counter = 0;
        if (round < colors.GetLength(0))
        {
            yield return new WaitForSeconds(2f);
            yield return SpawnMoles();
        }
        else
        {
            StopCoroutine(SpawnMoles());
        }
    }
    // Update is called once per frame
    void Update()
    {
        DetectPause();
    }
    void DetectPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();

        }
    }
    void TogglePause()
    {
        gamePaused = !gamePaused;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        pausePanel.SetActive(gamePaused);
    }
}