using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class SceneChange : MonoBehaviourPunCallbacks
{
    private int targetSceneIndex;
    public void LoadScene(int _index)
    {
        targetSceneIndex = _index;

        
        CleanupBeforeSceneChange();

        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("Photon hálózatról való leválasztás...");
            PhotonNetwork.Disconnect();
        }
        else
        {
            Debug.Log("Photon nincs csatlakozva. Azonnali jelenetváltás...");
            SceneManager.LoadScene(targetSceneIndex);
        }
    }

    
    public override void OnDisconnected(Photon.Realtime.DisconnectCause cause)
    {
        Debug.Log($"Photon leválasztva. Ok: {cause}. Jelenet betöltése...");
        SceneManager.LoadScene(targetSceneIndex); 
    }

    private void CleanupBeforeSceneChange()
    {
        
        var roomManager = FindObjectOfType<RoomManager>();
        if (roomManager != null)
        {
            Destroy(roomManager.gameObject);
        }

        
        var photonViews = FindObjectsOfType<PhotonView>();
        foreach (var view in photonViews)
        {
            if (view.IsMine && view.gameObject != null)
            {
                PhotonNetwork.Destroy(view.gameObject);
            }
        }
    }
}
