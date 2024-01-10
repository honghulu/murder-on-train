using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddToEvidenceScript : PlayerInterface
{
    public TextMeshProUGUI addingResult;
    public string[] evidenceList;
    bool inList;
    public GameObject[] otherElements;
    public TextMeshProUGUI[] discoveredEvidence;

    void Start()
    {
        inList = false;
    }
    public void addToEvidenceList()
    {
        if (type.text == "Evidence")
        {
            {
                
            }
            for (int i = 0; i < evidenceList.Length; i++)
            {
                if (title.text == evidenceList[i])
                {
                    inList = true;
                }
            }

            if (!inList)
            {
                addingResult.text = "Wrong evidence!";
            }
            else
            {
                if (discoveredEvidence.Length == 0)
                {
                    discoveredEvidence[0].text = title.text;
                }
                else
                {
                    inList = false;
                    for (int i = 0; i < discoveredEvidence.Length; i++)
                    {
                        if (discoveredEvidence[i].text == title.text)
                        {
                            inList = true;
                        }
                    }

                    if (inList)
                    {
                        addingResult.text = "Already added!";
                    }
                    else
                    {
                        int numberOfElements = 0;
                        for (int i = 0; i < discoveredEvidence.Length; i++)
                        {
                            if (discoveredEvidence[i].text == "?")
                            {
                                numberOfElements = i;
                            }
                        }
                        discoveredEvidence[numberOfElements].text = title.text;
                        addingResult.text = "Added successfully";
                    }
                }
            }
        }
    }
}

