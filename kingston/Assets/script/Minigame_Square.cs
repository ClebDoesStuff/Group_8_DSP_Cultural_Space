using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Minigame_Square : MonoBehaviour
{
    public SquaresOfTypeMinigame MinigameManager;
    public string GroupName;
    public bool Activated;
    public Color Colour;
    public string character;
    public TextMeshPro Text;

    public bool testinput;
    void Start()
    {
        Text = transform.GetChild(0).GetComponent<TextMeshPro>();
        Activated = false;
    }
    public void ResetState()
    {
        GroupName = "";
        Activated = false;
        Text.text = "";
        character = "";
        transform.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
        Colour = new Color(1f, 1f, 1f);
    }

    public void Selected()
    {
        Activated = true;
        Activated = MinigameManager.SquareSelected(GroupName);
        transform.GetComponent<Renderer>().material.color = Colour - new Color(0.5f, 0.5f, 0.5f);
        Text.text = character;
        // change colour to activated
    }

    public void Deactivate()
    {
        Activated = false;
        Text.text = "";
        transform.GetComponent<Renderer>().material.color = new Color(1f,1f,1f);
        // change colour to deactivated
    }

    void Update()
    {
        if (testinput)
        {
            Selected();
            testinput = false;
        }
    }
}
