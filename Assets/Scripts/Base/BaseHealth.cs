using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseHealth : MonoBehaviour
{
    private float maxHealth = 300f;
    public float currentBaseHealth;
    private float _damage = 25f;

    private void Start()
    {
        currentBaseHealth = maxHealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy"){ 
            TakeBaseDamage(_damage);
        }
    }
     void TakeBaseDamage(float amount)
    {
        currentBaseHealth -= amount;
        if (currentBaseHealth <= 0f)
        {
            Time.timeScale = 0f;
            //gameObject.gameObject.transform.position = new Vector3(11000, 10001, 1000);
           // gameObject.SetActive(false);
        }
    }
}
