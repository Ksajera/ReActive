using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.Types;
using System.Collections.Generic;

public class MatchMaker : MonoBehaviour
{
    //constants
    const int maxPlayers = Constants.MATCH_SIZE;
    const string password = Constants.MATCH_PASSWORD;
    const string matchName = Constants.MATCH_NAME;
    const int waitDelay = Constants.WAIT_DELAY;

    int tries = 0;

    MatchInfoSnapshot matchInfoSnapshot;

    void Start()
    {
        NetworkManager.singleton.StartMatchMaker();
        FindInternetMatch(matchName); //Tries to find existing matches and creates a match if none are found.

    }

    //call this method to request a match to be created on the server
    public void CreateInternetMatch(string matchName)
    {
        NetworkManager
            .singleton
            .matchMaker
            .CreateMatch(matchName,
            maxPlayers,
            true,
            password,
            "", "", 0, 0,
            OnInternetMatchCreate);

    }

    IEnumerator<WaitForSeconds> RetryJoinMatch()
    {
        Debug.Log("Trying to find match again...");
        yield return new WaitForSeconds(waitDelay);
        FindInternetMatch(matchName);
    }

    //this method is called when your request for creating a match is returned
    private void OnInternetMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (success)
        {
            Debug.Log("Create match succeeded");

            MatchInfo hostInfo = matchInfo;
            NetworkServer.Listen(hostInfo, 9000);

            NetworkManager.singleton.StartHost(hostInfo);
        }
        else
        {
            Debug.LogError("Create match failed");
            StartCoroutine("RetryJoinMatch");
        }
    }

    //call this method to find a match through the matchmaker
    public void FindInternetMatch(string matchName)
    {
        NetworkManager
            .singleton
            .matchMaker
            .ListMatches(
            0, 
            Constants.MATCH_MAX_ROOMS, 
            matchName, 
            true, 0, 0, 
            OnInternetMatchList);

    }

    //this method is called when a list of matches is returned
    private void OnInternetMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
    {
        if (success)
        {
            if (matches.Count != 0)
            {
                //Debug.Log("A list of matches was returned");

                //join the last server (just in case there are two...)
                NetworkManager
                    .singleton
                    .matchMaker
                    .JoinMatch(matches[matches.Count - 1]
                    .networkId,
                    "", "", "", 0, 0,
                    OnJoinInternetMatch);

                matchInfoSnapshot = matches[matches.Count - 1];

            }
            else
            {
                Debug.Log("No matches in requested room!");
                Debug.Log("Creating new room...");

                CreateInternetMatch(matchName);
            }
        }
        else
        {
            Debug.LogError("Couldn't connect to match maker");
            StartCoroutine("RetryJoinMatch");
        }
    }

    //this method is called when your request to join a match is returned
    private void OnJoinInternetMatch(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (success)
        {
            Debug.Log("Joined match.");

            MatchInfo hostInfo = matchInfo;
            NetworkManager.singleton.StartClient(hostInfo);

            Invoke("CheckClient", Constants.WAIT_DELAY);

        }

        else
        {
            Debug.LogError("Join match failed");
            StartCoroutine("RetryJoinMatch");

        }

    }

    void OnInternetMatchDestroy(bool success, string extendedInfo)
    {
        Debug.Log("Internet Match destroyed. Stopping client...");
        NetworkManager.singleton.StopClient();

    }

    void CheckClient()
    {
        
        if (tries >= Constants.MATCH_MAX_TRIES)
        {
            NetworkManager.singleton.matchMaker.DestroyMatch(NetworkManager.singleton.matchInfo.networkId, 0, OnInternetMatchDestroy);

        }

        if (ClientScene.localPlayers.Count < 1)
        {

            NetworkManager
                .singleton
                .matchMaker
                .DropConnection(
                NetworkManager.singleton.matchInfo.networkId,
                NetworkManager.singleton.matchInfo.nodeId,
                0,
                OnDropConnection);

        }

    }

    void OnDropConnection(bool success, string extendedInfo)
    {
        if (success)
        {
            FindInternetMatch(matchName);
            tries++;

        }

        else
        {
            Debug.Log("Failed to disconnect from match, disconnecting client from network...");
            NetworkManager.singleton.StopClient();

        }

    }

}