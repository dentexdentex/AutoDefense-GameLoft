using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
     public GameObject turret2;
 
   private bool isActive=false;
    
    public void test(Vector3 spawnPos)
    {
        if(isActive) return;
        isActive = true;
        if (isActive)
        {
            GameObject turret = Instantiate(turret2, Vector3.zero, Quaternion.identity);
            turret.transform.position = spawnPos;
            
        }
    }

    
}
