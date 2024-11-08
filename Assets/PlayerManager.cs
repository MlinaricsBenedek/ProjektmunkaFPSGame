using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView Pv;
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
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "FPSControllerPrefab"), Vector3.zero, Quaternion.identity);
    }
}
