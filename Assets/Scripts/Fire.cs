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
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Shot();
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
