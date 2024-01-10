using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ChooseKiller : MonoBehaviour
{
    public string killerName;
    public TextMeshProUGUI chosenCharacter;
    public TextMeshProUGUI[] discoveredEvidence;
    public TextMeshProUGUI errorLabel;
    public TextMeshProUGUI type;

    public void ChooseTheKiller()
    {
        if (type.text == "Character")
        {
            int numberOfEvidenceFound = 0;
            for (int i = 0; i < discoveredEvidence.Length; i++)
            {
                if (discoveredEvidence[i].text != "?")
                {
                    numberOfEvidenceFound++;
                }
            }
            if (numberOfEvidenceFound < 5)
            {
                errorLabel.text = "You do not have enough evidence!";
            }
            else
            {
                if (chosenCharacter.text == killerName)
                {
                    SceneManager.LoadScene("Win Scene");
                }
                else
                {
                    SceneManager.LoadScene("Lose Scene");
                }
            }
        }
    }
}
