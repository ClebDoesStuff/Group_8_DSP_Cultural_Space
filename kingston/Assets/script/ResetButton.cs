using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public SquaresOfTypeMinigame MinigameManager;
    public bool testbutton = false;
    
    public void ResetMinigame()
    {
        MinigameManager.ResetGame();
    }
    private void Update()
    {
        if (testbutton)
        {
            ResetMinigame();
            testbutton = false;
        }
    }
}
