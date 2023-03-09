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
    private Range _Range;

    List<Transform> _enemies = new List<Transform>();
 
    private AmmoPool _ammoPool;
    private Transform close;
    private Vector3 _turretInitialPos;

    public Xekseni xekseni;
    public Transform transformRotate;
    public float _range;
    private void Start()
    {
        _ammoPool = GetComponent<AmmoPool>();
        _spawnManager = GameObject.FindObjectOfType<SpawnManager>(); // ??
        _Range = GetComponent<Range>();
        StartCoroutine(Fire());
    }
    private void Update()
    { 
        close = GetClose(_spawnManager.GetEnemyPool()); //yok edilince erişelmiyor 

        if (Vector3.Distance(close.position, transform.position) > _range)
        {
            close = null;
        }

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

    public void Down()
    {
        _turretInitialPos = transform.position;
    }

    public void Drag()
    {
        var nextPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 
            Camera.main.WorldToScreenPoint(transform.position).z);
        var worldPos = Camera.main.ScreenToWorldPoint(nextPos);
        transform.position = new Vector3(worldPos.x, transform.position.y, worldPos.z);
        _Range.ClearLine();    
    }

    public void Up()
    {
        var ray = transform.up * - 10f;
        RaycastHit hit;
        if(!Physics.Raycast(transform.position,ray, out hit)) return;
        
        if(hit.collider.gameObject.CompareTag("area"))
        {
            transform.position = hit.transform.position;
            _Range.DrawCircle();
        }
        else
        {
            transform.position =_turretInitialPos ;
        }
        
    }
    
    /*
     *
     *
     * private void OnTriggerStay2D(Collider2D collision)
        string thisGameobjectName;
string collisionGameobjectName;
thisGameobjectName = gameObject.name.Substring(0, name.Indexof(". "));
collisionGameobjectName=collision.gameobject.name.Substring(0,name.Indexof("_"));
if (mouseButtonReleased && thisGameobjectName == "Acorn" && thisGameobjectName == collisionGameobjectName)
Instantiate(Resources.Load ("Oak_Object"), transform.position, Quaternion.identity);
mouseButtonReleased = false;
Destroy(collision.gameObject);
Destroy (gameobject);
}
else if (mouseButtonReleased && thisGameobjectName==
"Oak" && thisGameobjectName == collisionGameobjectName)
{
Instantiate(Resources.Load ("Rocket_Object"), transform.position, Quaternion.identity);
mouseButtonReleased = false;
Destroy(collision.gameobject);
Destroy (gameObject);
     */
}
