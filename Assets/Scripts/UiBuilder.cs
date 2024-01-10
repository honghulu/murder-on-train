using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiBuilder : MonoBehaviour
{
    public GameObject thisCanvas;
    public GameObject[] otherElements;
    public void unPause()
    {
        Time.timeScale = 1;
        for (int i = 0; i < otherElements.Length; i++)
        {
            otherElements[i].SetActive(true);
        }
        thisCanvas.SetActive(false);
    }
}
