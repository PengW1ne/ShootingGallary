using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M4PickUp : MonoBehaviour
{
    public GameObject M4;
    public GameObject Pistol;
    
    public GameObject M4_trigger;
    //public GameObject Pistol_trigger;

    public Text TextPickUpM4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            TextPickUpM4.text = "Нажмите E, чтобы взять карабин М4";
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            M4.SetActive(true);
            Pistol.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            TextPickUpM4.text = "";
        }
    }
}