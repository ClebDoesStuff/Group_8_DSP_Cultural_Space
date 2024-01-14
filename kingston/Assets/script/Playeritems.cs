using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Playeritems : MonoBehaviour
{
    public static int artefacts;
    public static bool teleporter1 = true;
    public static bool teleporter2 = true;
    public static bool teleporter3 = true;
    public static bool teleporter4 = true;
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
