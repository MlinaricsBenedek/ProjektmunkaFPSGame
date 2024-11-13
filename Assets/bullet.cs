using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{

   // [SerializeField] FPSController fps;
    public int bulletDamage = 40;
    public float bulletSpeed = 20f;
    Rigidbody rb;

    private void Update()
    {
        shootBullet();
    }
    public void shootBullet()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            Destroy(gameObject);
        }
    }
}
