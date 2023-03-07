using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;

    private void FixedUpdate()
    {
        transform.position += transform.forward * Time.deltaTime * 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        
            Health enemyHealth = other.gameObject.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            gameObject.SetActive(false); //mermiyi kapatıyoruz
    }
}