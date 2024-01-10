using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPage : MonoBehaviour
{
    public EvidenceInteraction currentInteraction;

    public void nextPage()
    {   if (currentInteraction.currentIndex < currentInteraction.objectInformation.Length - 1)
        {
            currentInteraction.description.text = currentInteraction.objectInformation[++currentInteraction.currentIndex];
        }
    }
}
