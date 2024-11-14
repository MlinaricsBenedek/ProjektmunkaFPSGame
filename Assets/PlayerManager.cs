using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView Pv;
    GameObject controller;
    private void Awake()
    {
        Pv = GetComponent<PhotonView>();
    }
    void Start()
    {
        if (Pv.IsMine)
        {
            CreateController();
        }
    }

    // Update is called once per frame
    void CreateController()
    {
       controller= PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "FPSControllerPrefab"), Vector3.zero, Quaternion.identity, 0, new object[] { Pv.ViewID });
    }
    public void Die()
    {
        Debug.Log("Destroy the player");
        PhotonNetwork.Destroy(controller);
        CreateController();
    }
   

}
