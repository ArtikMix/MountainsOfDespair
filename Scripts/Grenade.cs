using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    //public GameObject explosionEffect;
    private float countDown;
    private bool hasExploded = false;
    public float radius = 50f;
    public float exForce = 70f;
    CharacterStats cStats;

    void Start()
    {
        cStats = GetComponent<CharacterStats>();
        countDown = delay;
    }
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0 && hasExploded == false)
        {
            Explode();
        }
    }

    void Explode()
    {
        hasExploded = true;
        //Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(exForce, transform.position, radius);
                if (rb.tag == "Enemy")
                {
                    //cStats.TakeDamage(60);
                }
            }
        }
        Destroy(gameObject);
        Debug.Log("Boom");
    }
}
