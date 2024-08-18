using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    [SerializeField] GameObject Playerr;

 
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue("PlayerName", out object playerName))
        {
            Debug.Log("Player Name: " + (string)playerName);
            // Use the player name as needed
        }
        else
        {
            Debug.LogError("Player Name not found.");
        }



        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.Instantiate(Playerr.name,new Vector3 (0, 0,0), Quaternion.identity);
          
        }
    }
    public void BallSpawner() 
    {
        PhotonNetwork.Instantiate(Ball.name, new Vector3(0, 0, 0), Quaternion.identity);
    }

  
}
