using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeCaller : MonoBehaviour
{
    private Merge merge;

    private void Start()
    {
        merge = GameObject.FindObjectOfType<Merge>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (gameObject.tag == col.tag)
        {
            Destroy(col.gameObject);
            Debug.Log("if (gameObject.tag == col.tag) çalıştı");
            merge.test(transform.position);
        }
    }
}
