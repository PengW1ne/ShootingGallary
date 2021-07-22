using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Fire : MonoBehaviour
{
    public FirstPersonController FirstPersonController;
    public Weapon weapon;
    public GameObject targetLook;
    public GameObject playerCamera;
    
    private bool shotbool = true;
    
    public ParticleSystem muzzle;
    public AudioSource audioSource;
    public AudioClip shootClip;


    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
            if (weapon.name == "Pistol")
            {
                FirstPersonController.enableZoom = false;
                if (Input.GetMouseButtonDown(0))
                {
                    if (shotbool)
                    {
                        StartCoroutine(PistolShootDelay());
                    }
                }
            }
            else if (weapon.name == "M4")
            {
                FirstPersonController.enableZoom = true;
                if (Input.GetMouseButton(0))
                {
                    if (shotbool)
                    {
                        StartCoroutine(M4ShootDelay());
                    }
                }
                
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
    
    
    IEnumerator PistolShootDelay()
    {
        weapon.Shot();
        muzzle.Play();
        audioSource.PlayOneShot(shootClip);
        
        shotbool = false;
        yield return new WaitForSeconds(.2f);
        shotbool = true;
    }

    IEnumerator M4ShootDelay()
    {
        weapon.Shot();
        muzzle.Play();
        audioSource.PlayOneShot(shootClip);
        
        shotbool = false;
        yield return new WaitForSeconds(.05f);
        shotbool = true;
    }
}
