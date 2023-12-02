using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cueball : MonoBehaviour
{
    public Rigidbody rb;
    float timer = 2;
    public bool iscontrol = false;
    public Camera mainCamera;
    public LineRenderer lr;
    Vector3 startpoint;
    Vector3 endpoint;
    public Material red;
    public Material yellow;
    public Material blue;
    // Start is called before the first frame update
    void Start()
    {
        lr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        
        float z = Input.GetAxis("Vertical");
        Vector3 force = new Vector3(x, 0, z);
        /*Vector3 force=new Vector3(x,rb.velocity.y,z);  
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up, ForceMode.Impulse);
        }*/
        GetComponent<Rigidbody>().AddForce(force*0.01f,ForceMode.Impulse);
        
        
      
        /*timer-= Time.deltaTime;
        if(timer <0) {
           Debug.Log(rb.velocity.ToString());
            timer = 2;
                }*/
        /*if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            iscontrol = true;
        }
        else if(!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            iscontrol = false;
        }*/
        if(Input.GetMouseButton(0))
        {
            lr.enabled = true;
            startpoint=transform.position;
            endpoint = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.y-0.5f));
            lr.SetPosition(0, endpoint);
            lr.SetPosition(1, startpoint);
            iscontrol = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            lr.enabled = false;
            Vector3 dir = startpoint - endpoint;
            Debug.Log(dir.ToString());
            GetComponent<Rigidbody>().AddForce(dir * -2f, ForceMode.Impulse);
            

        }



    }
    private void FixedUpdate()
    {
        rb.velocity *= 0.987f;//just a number  
        if(rb.velocity.sqrMagnitude > 0.1) { iscontrol = false; }
        if (rb.velocity.sqrMagnitude <= 0.1 & !iscontrol)
        {
            rb.velocity = Vector3.zero;
            
        }
    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.transform.tag == "red")
        {
            other.transform.tag = "yellow";
            other.collider.GetComponent<MeshRenderer>().material = yellow;
        }
        else if (other.transform.tag == "yellow")
        {
            other.transform.tag = "blue";
            other.collider.GetComponent<MeshRenderer>().material = blue;
        }
        else if (other.transform.tag == "blue")
        {
            other.transform.tag = "red";
            other.collider.GetComponent<MeshRenderer>().material = red;
        }
    }



}
