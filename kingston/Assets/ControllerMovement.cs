using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerMovement : MonoBehaviour
{
    public InputActionReference joystick;
    public Vector2 direction;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = joystick.action.ReadValue<Vector2>();

        /*
          
        // this almost allows you to look in the direction you want to go and use the joystick
        
        Debug.Log("1 "+transform.parent.GetChild(0).localRotation.y);
        Debug.Log("2 "+ transform.parent.GetChild(0).rotation.y * 360);
        
        Quaternion rot = Quaternion.Euler(transform.parent.parent.transform.rotation.x, transform.parent.GetChild(0).localRotation.y * 360, transform.parent.parent.transform.rotation.z);
        transform.parent.parent.transform.rotation = rot;
        */
        transform.parent.parent.transform.Translate(new Vector3(direction.x * speed * Time.deltaTime,0,direction.y * speed * Time.deltaTime), Space.Self);
    }
}
