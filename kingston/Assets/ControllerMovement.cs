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
        Debug.Log(direction);
        transform.parent.parent.transform.Translate(new Vector3(direction.x * speed * Time.deltaTime,0,direction.y * speed * Time.deltaTime));
    }
}
