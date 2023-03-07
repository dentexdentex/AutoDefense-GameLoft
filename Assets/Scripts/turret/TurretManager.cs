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
 
    private AmmoPool _ammoPool;
    private Transform close;
    
    public Xekseni xekseni;
    public Transform transformRotate;
    public float _range;
    private void Start()
    {
        _ammoPool = FindObjectOfType<AmmoPool>();
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
        return close;
    }
    void Shoot(Quaternion x)
    {
        _ammoPool.CaLL(x);
    }
}
