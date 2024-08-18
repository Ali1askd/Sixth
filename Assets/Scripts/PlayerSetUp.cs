using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSetUp : MonoBehaviourPunCallbacks
{
   public GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    public Vector3 MasterPlayerPosition = new Vector2(-9, 0);
    public Vector3 LocalPlayerPosition = new Vector2(9, 0);
    Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        int actorNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        
        Debug.Log($"Actor Number: {actorNumber}");
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (photonView.IsMine) 
        {
            Debug.Log("Mine");
            spriteRenderer.color = Color.blue;   
            GetComponent<Player1>().enabled = true;

        } 
        else 
        {
            spriteRenderer.color = Color.red;
            GetComponent<Player1>().enabled = false;
        }
        if (PhotonNetwork.PlayerList.Length == 1)
        {
         //   spawnPosition = LocalPlayerPosition;
        }
        else if (PhotonNetwork.PlayerList.Length == 2)
        {
          //  spawnPosition = MasterPlayerPosition;
        }
        else
        {
            Debug.LogError("More than 2 players are not supported.");
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
