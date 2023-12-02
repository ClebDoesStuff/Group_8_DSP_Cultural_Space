using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class otherball : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 m_preVelocity= Vector3.zero;
    float timer = 2;
    Transform me;
    public Material red;
    public Material yellow;
    public Material blue;
    public Material mymaterial;
    public MeshRenderer myRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        me = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.velocity *= 0.987f;//just a number
        if (rb.velocity.sqrMagnitude <= 0.1)
        {
            rb.velocity = Vector3.zero;
        }
    }
    private void OnCollisionEnter (Collision collision)
    {

        if (collision.transform.tag == transform.tag)
        {
            Destroy(gameObject);
        }
        





    }
    private void OnCollisionExit(Collision collision)
    {
        /*if (collision.collider.transform.tag == "yellow")
        {
            
            myRenderer.material = yellow;
            me.tag = "yellow";
        }
        else if (collision.collider.transform.tag == "red")
        {
            
            myRenderer.material = red; 
            me.tag = "red";
        }
        else if (collision.collider.transform.tag == "blue")
        {
            
            myRenderer.material = blue;
            me.tag="blue";
        }*/



        if (collision.transform.tag == "cusion" & me.tag == "red")
        {
            me.tag = "yellow";
            myRenderer.material = yellow;
        }
        else if (collision.transform.tag == "cusion" & me.tag == "yellow")
        {
            me.tag = "blue";
            myRenderer.material = blue;
        }
        else if (collision.transform.tag == "cusion" & me.tag == "blue")
        {
            me.tag = "red";
            myRenderer.material = red;
        }
        

    }



}
