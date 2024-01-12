using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableHole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ball entered");
        if (other.gameObject.name == "ball") // if ball enters trigger hitbox
        {

        }
    }
}
