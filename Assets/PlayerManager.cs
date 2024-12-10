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

    
    void CreateController()
    {
        Transform spawnPoint=SpawnManager.instance.GetSpawnPoint();
       controller= PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "FPSControllerPrefab"), spawnPoint.position,spawnPoint.rotation, 0, new object[] { Pv.ViewID });
    }
    /*public void Die()
    {
        Debug.Log("Destroy the player");
        PhotonNetwork.Destroy(controller);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //CreateController();
    } */
    public void Die()
    {
        Debug.Log("Destroy the player");

        
        PhotonNetwork.Destroy(controller);

        string winnerName = PhotonNetwork.PlayerListOthers[0].NickName;

        
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("GameOver", RpcTarget.All, winnerName);
    }

    
    [PunRPC]
    void GameOver(string winnerName)
    {
        GameOverManager.winnerName = winnerName;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

   

}
