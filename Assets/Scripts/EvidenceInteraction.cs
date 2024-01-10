using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EvidenceInteraction : PlayerInterface
{
    public string objectType;
    public string objectName;
    public string buttonLabel;
    public GameObject interactionCanvas;
    public TextMeshProUGUI description;
    public TextMeshProUGUI label;
    public GameObject[] otherElements;
    public string[] objectInformation;
    public int currentIndex;
    public NextPage UI;

    public void OnMouseDown()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) > 5)
        {
            return;
        }
        UI.currentInteraction = this;
        title.text = objectName;
        description.text = objectInformation[currentIndex];
        label.text = buttonLabel;
        type.text = objectType;
        
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            for (int i = 0; i < otherElements.Length; i++)
            {
                otherElements[i].SetActive(true);
            }
            interactionCanvas.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            for (int i = 0; i < otherElements.Length; i++)
            {
                otherElements[i].SetActive(false);
            }
            interactionCanvas.SetActive(true);
        }
    }

}
