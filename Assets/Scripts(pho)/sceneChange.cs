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

        // Cleanup RoomManager vagy más globális objektumok
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

    // Callback: Akkor hívódik meg, ha a Photon sikeresen leválasztott
    public override void OnDisconnected(Photon.Realtime.DisconnectCause cause)
    {
        Debug.Log($"Photon leválasztva. Ok: {cause}. Jelenet betöltése...");
        SceneManager.LoadScene(targetSceneIndex); // Jelenet betöltése a leválasztás után
    }

    private void CleanupBeforeSceneChange()
    {
        // Töröld az összes DontDestroyOnLoad objektumot, ha szükséges
        var roomManager = FindObjectOfType<RoomManager>();
        if (roomManager != null)
        {
            Destroy(roomManager.gameObject);
        }

        // Töröld a Photon által kezelt objektumokat
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
