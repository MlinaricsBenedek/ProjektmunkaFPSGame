using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class BulletController : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField]Transform gunPosition;
    [SerializeField] bullet bullet;
    public void CreatePrefab()
    {
        GameObject gm = Instantiate(bulletPrefab, gunPosition.transform.position,gunPosition.transform.rotation);
        
    }


}
