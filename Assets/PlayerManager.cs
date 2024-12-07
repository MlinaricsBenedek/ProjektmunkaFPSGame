using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.SceneManagement;

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
        Transform spawnPoint=SpawnManager.instance.GetSpawnPoint();
       controller= PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "FPSControllerPrefab"), spawnPoint.position,spawnPoint.rotation, 0, new object[] { Pv.ViewID });
    }
    public void Die()
    {
        Debug.Log("Destroy the player");
        PhotonNetwork.Destroy(controller);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //CreateController();
    }
   

}
