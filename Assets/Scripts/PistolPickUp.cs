using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistolPickUp : MonoBehaviour
{
    public GameObject M4;
    public GameObject Pistol;
    
    public GameObject Pistol_trigger;

    public Text TextPickUpPistol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            TextPickUpPistol.text = "Нажмите E, чтобы взять пистолет";
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pistol.SetActive(true);
            M4.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            TextPickUpPistol.text = "";
        }
    }
}