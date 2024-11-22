using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonResults : MonoBehaviour
{
    public void ChargeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
