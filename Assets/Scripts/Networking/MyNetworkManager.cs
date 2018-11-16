using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager {

    const int maxPlayers = 2;
    Player[] playerSlots = new Player[maxPlayers + 1];

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        for (int slot=1; slot < maxPlayers + 1; slot++)
        {
            if (playerSlots[slot] == null)
            {
                Vector3 playerSpawnPos = GetStartPosition().position;
                var objPlayer = (GameObject)GameObject.Instantiate(playerPrefab, playerSpawnPos, Quaternion.identity);
                var player = objPlayer.GetComponent<Player>();

                player.playerID = slot;
                playerSlots[slot] = player;

                NetworkServer.AddPlayerForConnection(conn, objPlayer, playerControllerId);
                return;
            }

        }

    }

    private void OnDisconnectedFromServer()
    {
        Debug.Log("Disconnected.");
    }

}
