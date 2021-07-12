using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Fire : MonoBehaviour
{
    public Weapon weapon;
    public GameObject targetLook;
    public GameObject playerCamera;
    
    public ParticleSystem muzzle;
    public AudioSource audioSource;
    public AudioClip shootClip;


    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Shot();
            muzzle.Play();
            //audioSource.PlayOneShot(shootClip);
        }   
        
        TargetLook();
    }

    private void TargetLook()
    {
        Ray ray = new Ray(playerCamera.transform.position,playerCamera.transform.forward * 2000);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            targetLook.transform.position = Vector3.Lerp(targetLook.transform.position, hit.point, Time.deltaTime * 40);
        }
    }
}
