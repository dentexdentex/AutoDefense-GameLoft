using System;
using Base;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    public float stoppingDistance = 1f;
    public float retreatDistance = 0.5f;
    private void FixedUpdate()
    {
        if (BaseHealth.Instance.transform == null)
        {
            return;
        }
        if (Vector3.Distance(transform.position, BaseHealth.Instance.transform.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, BaseHealth.Instance.transform.position, speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, BaseHealth.Instance.transform.position) < stoppingDistance && Vector3.Distance(transform.position, BaseHealth.Instance.transform.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector3.Distance(transform.position, BaseHealth.Instance.transform.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, BaseHealth.Instance.transform.position, -speed * Time.deltaTime);
        }
    }
}