using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private float damage;  

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.gameObject.CompareTag(targetTag))
        {
            other.gameObject.GetComponent<Health>().Damage(damage);
        }
        Destroy(gameObject);
    }
}
