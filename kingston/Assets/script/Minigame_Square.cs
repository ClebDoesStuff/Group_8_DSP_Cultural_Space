using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame_Square : MonoBehaviour
{
    public SquaresOfTypeMinigame MinigameManager;
    public string GroupName;
    public bool Activated;
    public Color Colour;
    void Start()
    {
        GroupName = "";
        Activated = false;
        //transform.GetComponent<Renderer>().material.color = new Color(1,1,1);
        // change colour to deactivated
    }

    public void Selected()
    {
        Activated = true;
        Activated = MinigameManager.SquareSelected(GroupName);
        transform.GetComponent<Renderer>().material.color = Colour - new Color(0.1f, 0.1f, 0.1f);
        // change colour to activated
    }

    public void Deactivate()
    {
        Activated = false;
        transform.GetComponent<Renderer>().material.color = new Color(1f,1f,1f);
        // change colour to deactivated
    }
}
