using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartFireLineTrigger : MonoBehaviour
{
    private Weapon _weapon;
    
    public Text StartFireLineText;
    public AudioSource audioSource;
    public AudioClip KlaxonClip;


    private bool readyForShooting;
    private bool isShotting;

    private void Start()
    {
        _weapon = FindObjectOfType<Weapon>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
                if (_weapon.transform.GetChild(0).gameObject.activeInHierarchy ||
                    _weapon.transform.GetChild(1).gameObject.activeInHierarchy)
                {
                    StartFireLineText.text = "Нажмите E, чтобы начать тренировку на мешенях";
                    readyForShooting = true;
                }
                else
                {
                    StartFireLineText.text = "Сперва возьмите оружее на верстоках сзади";
                    readyForShooting = false;
                }
            
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (!isShotting)
        {
            if (readyForShooting)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isShotting = true;
                    audioSource.PlayOneShot(KlaxonClip);
                    StartFireLineText.text = "";
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartFireLineText.text = "";
        }
    }
}