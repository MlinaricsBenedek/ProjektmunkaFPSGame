using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{

   [SerializeField] FPSController fps;
    public float bulletDamage = 40;
    public float bulletSpeed = 20f;
    Rigidbody rb;

    private void Update()
    {
        shootBullet();
    }
    public void shootBullet()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        { if (collision.gameObject.tag.Equals("Player"))
            {
                if (fps == null)
                {
                    Debug.Log("az fps null a bullet scriptbe!!!!");
                }
                Debug.Log("A golyo utkozott a playerrel, megh�vjuk a takedamaget!");
              fps.setIsGetDamage(true);
            }
            Destroy(gameObject);
        }
    }
}
