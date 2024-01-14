using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerMovement : MonoBehaviour
{
    public InputActionReference RightAButtonActionReference;
    public InputActionReference RightBButtonActionReference;
    public GameObject Text;
    public float RightAButton;
    public float RightBButton;
    public XRRayInteractor RayI;
    public RaycastHit hit;
    public float speed;
    public bool AButtonDown;
    public bool BButtonDown;
    // Start is called before the first frame update
    void Start()
    {
        AButtonDown = false;
        BButtonDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        RightAButton = RightAButtonActionReference.action.ReadValue<float>();
        RightBButton = RightBButtonActionReference.action.ReadValue<float>();
        if (RightAButton == 1 && !AButtonDown)
        {
            AButtonDown = true;
            if (RayI.TryGetCurrent3DRaycastHit(out hit)){
                if (hit.transform.gameObject.GetComponent<Minigame_Square>() != null)
                {
                    hit.transform.gameObject.GetComponent<Minigame_Square>().Selected();
                }
                if (hit.transform.gameObject.GetComponent<ResetButton>() != null)
                {
                    hit.transform.gameObject.GetComponent<ResetButton>().ResetMinigame();
                }
            }
        }
        if (RightAButton == 0)
        {
            AButtonDown = false;
        }
        if (RightBButton == 1 && !BButtonDown)
        {
            BButtonDown = true;
            Text.SetActive(!Text.activeSelf);
        }
        if (RightBButton == 0)
        {
            BButtonDown = false;
        }
    }
}
