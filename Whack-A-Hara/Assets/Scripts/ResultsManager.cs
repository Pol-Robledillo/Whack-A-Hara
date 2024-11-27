using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultsManager : MonoBehaviour
{

    public TextMeshProUGUI deuta;
    public TextMeshProUGUI prota;
    public TextMeshProUGUI azulAm;
    void Start()
    {
        deuta.text = PlayerPrefs.GetString("deuta", "sin resultado");
        prota.text = PlayerPrefs.GetString("prota", "sin resultado");
        azulAm.text = PlayerPrefs.GetString("azulAm", "sin resultado");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
}
