using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour
{
    public string teleporterNo;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (teleporterNo == "1"){ Playeritems.teleporter1 = false; }
            if (teleporterNo == "2"){ Playeritems.teleporter2 = false; }
            if (teleporterNo == "3"){ Playeritems.teleporter3 = false; }
            if (teleporterNo == "4"){ Playeritems.teleporter4 = false; }
            SceneManager.LoadSceneAsync(1);
        }
    }
    void Start()
    {
        if (teleporterNo == "1" && Playeritems.teleporter1 == false) { transform.gameObject.SetActive(false); }    
        if (teleporterNo == "2" && Playeritems.teleporter2 == false) { transform.gameObject.SetActive(false); }    
        if (teleporterNo == "3" && Playeritems.teleporter3 == false) { transform.gameObject.SetActive(false); }    
        if (teleporterNo == "4" && Playeritems.teleporter4 == false) { transform.gameObject.SetActive(false); }
    }
}
