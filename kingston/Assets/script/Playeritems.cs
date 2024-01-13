using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Playeritems : MonoBehaviour
{
    public int artefacts;
    public TextMeshPro Text;

    void Start()
    {
        artefacts = 0;    
    }

    void Update()
    {
        Text.text = "artefacts: " + artefacts + " / 4";
    }
}
