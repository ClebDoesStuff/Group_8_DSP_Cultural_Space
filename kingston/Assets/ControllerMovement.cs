using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerMovement : MonoBehaviour
{
    public InputActionReference joystick;
    public InputActionReference RightAButtonActionReference;
    public float RightAButton;
    public XRRayInteractor RayI;
    public RaycastHit hit;
    public Vector2 direction;
    public float speed;
    public bool AButtonDown;
    // Start is called before the first frame update
    void Start()
    {
        AButtonDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        RightAButton = RightAButtonActionReference.action.ReadValue<float>();
        direction = joystick.action.ReadValue<Vector2>();
        transform.parent.parent.transform.Translate(new Vector3(direction.x * speed * Time.deltaTime,0,direction.y * speed * Time.deltaTime), Space.Self);
        if (RightAButton == 1 && !AButtonDown)
        {
            AButtonDown = true;
            if (RayI.TryGetCurrent3DRaycastHit(out hit)){
                if (hit.transform.gameObject.GetComponent<Minigame_Square>() != null)
                {
                    hit.transform.gameObject.GetComponent<Minigame_Square>().Selected();
                }
            }
        }
        if (RightAButton == 0)
        {
            AButtonDown = false;
        }
    }
}
