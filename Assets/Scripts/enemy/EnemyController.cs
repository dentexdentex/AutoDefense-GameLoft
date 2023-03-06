using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    public float stoppingDistance = 1f;
    public float retreatDistance = 0.5f;
    public Transform target;

    private void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }
        if (Vector3.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, target.position) < stoppingDistance && Vector3.Distance(transform.position, target.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector3.Distance(transform.position, target.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
    }
}