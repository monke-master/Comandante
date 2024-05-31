using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float explosionPower = 5000;
    [SerializeField] private Animator animator;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody2D>().AddForce(Vector2.up*explosionPower);
            other.GetComponent<Health>().Damage(10000);
            animator.enabled = true;
            Destroy(transform.Find("Mine").gameObject);
        }
    }
}
