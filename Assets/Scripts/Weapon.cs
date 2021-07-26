using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public Transform shotPoint;
    public Transform targetLook;
    public GameObject bullet;

    

   

    private void Update()
    {
        shotPoint.LookAt(targetLook);
    }

    public void Shot()
    {
        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
    }
    
}
