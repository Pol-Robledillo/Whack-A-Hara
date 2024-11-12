using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalMoles, counter = 0;
    public float minWaitTime, maxWaitTime;
    public bool GamePaused = false;
    public GameObject[] moles;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMoles());
    }
    IEnumerator SpawnMoles()
    {
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
        GamePaused = !GamePaused;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
}