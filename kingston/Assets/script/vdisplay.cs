using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vdisplay : MonoBehaviour
{
    public Rigidbody body;
    public Vector3 v;
    public float vlength;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        v=body.velocity;
        vlength = v.magnitude;
       
    }
}
