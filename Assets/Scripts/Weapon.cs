using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public Transform shotPoint;
    public Transform targetLook;

    public GameObject camera;
    public GameObject decal;

    public GameObject bullet;

    private void Update()
    {
        shotPoint.LookAt(targetLook);
        Vector3 origin = shotPoint.position;
        Vector3 dir = targetLook.position;

        RaycastHit hit;
    }

    public void Shot()
    {

        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
    }
    
}
