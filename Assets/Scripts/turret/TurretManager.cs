using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class TurretManager : MonoBehaviour
{
    private SpawnManager _spawnManager;

    List<Transform> _enemies = new List<Transform>();

    public float _range;
    private AmmoPool _ammoPool;

    // public GameObject Bullet;
   // public Transform head, barrel;
    public float FireRate, NextFire;
    
    public Xekseni xekseni;
    public Transform transformRotate;
    private Transform close;
    private void Start()
    {
        _ammoPool = FindObjectOfType<AmmoPool>();
      //  target=GameObject.FindObjectOfType<SpawnManager>();
        _spawnManager = GameObject.FindObjectOfType<SpawnManager>(); // ??
        StartCoroutine(Fire());

    }
    private void Update()
    { 
        close = GetClose(_spawnManager.GetEnemyPool()); //yok edilince erişelmiyor 

        if (Vector3.Distance(close.position, transform.position) > _range)
        {
            close = null;
        }
        
        Debug.Log(close);

        if (close != null)
        {
            xekseni.Xeksen(close);
            
            
            
            // Debug.Log(close.GetInstanceID()+"2");
            // transformRotate.LookAt(close);

            // if (Time.time >= NextFire)
            // {
            //     NextFire = Time.time + 1f / FireRate;
            //     Shoot(transformRotate.transform.rotation);
            //     // if (_ammoPool._bulletCoroutine is null) return;//mermi biterse 
            //     // StopCoroutine(_ammoPool._bulletCoroutine);
            //     // _ammoPool._bulletCoroutine = null;
            // }
        }
    }

    private WaitForSeconds waitForHalfSecond = new WaitForSeconds(.25f);
    IEnumerator Fire()
    {
        yield return waitForHalfSecond;
        if(close!= null)
            Shoot(transformRotate.transform.rotation);
        StartCoroutine(Fire());

    }
    
    public Transform GetClose (List<Transform> theList)
    {
        if (theList.Count == 0)
            return null;
        
        var close = theList.OrderBy(x => Vector3.Distance(transform.position, x.transform.position))?.First();
        //Debug.Log(close.GetInstanceID());
        return close;
    }
    //public AmmoPool _ammoPool;
    void Shoot(Quaternion x)
    {
        _ammoPool.CaLL(x);
        //GameObject clone = Instantiate(Bullet, barrel.position, transform.rotation);
      //  clone.GetComponent<Rigidbody>().AddForce(transform.forward * 250);
    }
}
