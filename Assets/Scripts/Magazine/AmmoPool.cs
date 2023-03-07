using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AmmoPool : MonoBehaviour
{   
    [FormerlySerializedAs("cubePrefab")] public GameObject bulletPrefab; // atılacak küpün prefab'ı
    [FormerlySerializedAs("cubeSpeed")] public float bulletSpeed = 5f; // küplerin hızı
    public Coroutine _bulletCoroutine;
    public float destroyDelay = 3f; // küplerin yok olma süresi
    private List<GameObject> cubePool = new List<GameObject>(); // object pool'umuz
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject cube = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity );
            cube.SetActive(false);
            cubePool.Add(cube);
        }
    }
    /*void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
                if(_bulletCoroutine is not null) return;
                _bulletCoroutine = StartCoroutine(TryBulletSpawn());
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if(_bulletCoroutine is null) return;
                StopCoroutine(_bulletCoroutine);
                _bulletCoroutine = null;
            } 
    }*/
    public void CaLL(Quaternion quaternion)
    {
        GameObject bullet = GetPooledCube();
        if (bullet != null)
        {
            bullet.SetActive(true);
            bullet.transform.position = transform.position + transform.up * 1.5f; //önğnden ateşle
            bullet.transform.rotation = quaternion;

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
              
            //rb.velocity = transform.up * bulletSpeed;
            StartCoroutine(DestroyCube(bullet));
        }
    }

    GameObject GetPooledCube()
    {// object pool'dan kullanılabilir bir küp alıyoruz
        for (int i = 0; i < cubePool.Count; i++)
        {
            if (!cubePool[i].activeInHierarchy)
            {
                //Debug.Log(cubePool[i]+"sdfsfdsf");
                return cubePool[i];
            }
            else
            {
                //Debug.Log("getpooledcube else");

            }
        }
        return null;
    }
    IEnumerator DestroyCube(GameObject cube)
    {
        yield return new WaitForSeconds(destroyDelay);
        cube.SetActive(false); //küpleri kapatıyoruz
    }
}
