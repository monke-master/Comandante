using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private float damage;

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.gameObject.CompareTag(targetTag))
        {
            other.gameObject.GetComponent<Health>().Damage(damage);
        }

        StartCoroutine(DestroyCoroutine());
    }
}
