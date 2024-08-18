using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using UnityEngine.UI;
public class PlayerProperties : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text player1NameText;
    [SerializeField] private Text player2NameText;
    void Start()
    {
        // Ensure we are connected to the Photon network
        if (!PhotonNetwork.IsConnected)
        {
            Debug.LogError("Not connected to Photon Network.");
            return;
        }

        // Check if we are in a room
        if (PhotonNetwork.InRoom)
        {
            Debug.Log("Current room: " + PhotonNetwork.CurrentRoom.Name);
            DisplayPlayerNames();
        }
        else
        {
            Debug.LogWarning("Not currently in a room.");
        }
    }

    void DisplayPlayerNames()
    {
        // Get all players in the current room
        Player[] players = PhotonNetwork.PlayerList;
        if (players.Length <= 2)
        {
            // Assign player names to Text components
            player1NameText.text = players[0].NickName;
            player2NameText.text = players[1].NickName;
        }

        else
        {
            Debug.LogWarning("Not enough players in the room to assign names separately.");
        }
    }
}
