using UnityEngine;
using Photon.Pun;

public class GameOverManager : MonoBehaviour
{
    public static string winnerName; 

    public Canvas victoryCanvas;
    public Canvas defeatCanvas;

    void Start()
    {
        string localPlayerName = PhotonNetwork.LocalPlayer.NickName;

        if (localPlayerName == winnerName)
        {
            
            victoryCanvas.gameObject.SetActive(true);
            defeatCanvas.gameObject.SetActive(false);
        }
        else
        {
            
            victoryCanvas.gameObject.SetActive(false);
            defeatCanvas.gameObject.SetActive(true);
        }
    }
}
