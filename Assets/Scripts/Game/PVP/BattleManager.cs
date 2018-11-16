using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BattleManager : NetworkBehaviour {

    List<Player> playerList;
    public bool ready;

    Text txtPlayerHP;
    Text txtOppHP;

    Player localplayer;
    Player opponent;

    RectTransform RectPlayerHealthBar;
    RectTransform RectOpponentHealthBar;

    Transform OpponentSpawn;
    public Image GameOverScreen;

    CountdownTimer countdown;

    public static BattleManager singleton = null;

    void Awake()
    {
        if (singleton == null)
            singleton = this;

        else if (singleton != this)
            Destroy(gameObject);

    }

    void Start()
    {
        ready = false;
        StartBattle();
            
        txtPlayerHP = GameObject.Find("txt_PlayerHP").GetComponentInChildren<Text>();
        txtOppHP = GameObject.Find("txt_OppHP").GetComponentInChildren<Text>();

        RectPlayerHealthBar = GameObject.FindGameObjectWithTag("PLAYER_HP_BAR").GetComponent<RectTransform>();
        RectOpponentHealthBar = GameObject.FindGameObjectWithTag("OPPONENT_HP_BAR").GetComponent<RectTransform>();

        OpponentSpawn = GameObject.Find("OpponentSpawn").GetComponent<Transform>();
        GameOverScreen = GameObject.FindGameObjectWithTag(Constants.TAG_GAMEOVER).GetComponent<Image>();

    }

    void Update()
    {
        if (ready)
        {
            txtPlayerHP.text = localplayer.HP.ToString();
            txtOppHP.text = opponent.HP.ToString();

            //float currentBoundsX;
            //float newBoundsX;

            //Health Bar

            //currentBoundsX = RectPlayerHealthBar.GetComponent<Renderer>().bounds.min.x;
            RectPlayerHealthBar.sizeDelta = new Vector2(((float)localplayer.HP/(float)localplayer.MaxHP) * Constants.HUD_HP_BAR_WIDTH, RectPlayerHealthBar.sizeDelta.y);
            //newBoundsX = RectPlayerHealthBar.GetComponent<Renderer>().bounds.min.x;
            
            //if(currentBoundsX != newBoundsX)
            //    RectPlayerHealthBar.transform.Translate(new Vector3(currentBoundsX - newBoundsX, 0f, 0f));

            //currentBoundsX = RectOpponentHealthBar.GetComponent<Renderer>().bounds.min.x;
            RectOpponentHealthBar.sizeDelta = new Vector2(((float)opponent.HP/(float)opponent.MaxHP) * Constants.HUD_HP_BAR_WIDTH, RectOpponentHealthBar.sizeDelta.y);
            //newBoundsX = RectOpponentHealthBar.GetComponent<Renderer>().bounds.min.x;

            //if (currentBoundsX != newBoundsX)
            //    RectOpponentHealthBar.transform.TransformDirection(new Vector3(currentBoundsX - newBoundsX, 0f, 0f));


            if (playerList[0].HP <= 0)
            {
                EndBattle(playerList[0].playerID);
            }

            if (playerList[1].HP <= 0)
            {
                EndBattle(playerList[1].playerID);
            }

        }

    }

    public void CountdownEnd()
    {
        for (int i = 0; i < playerList.Count; i++)
        {
            if (playerList[i].HP < playerList[i].HP)
            {
                EndBattle(playerList[i].playerID);
            }
        }
    }

    public void EndBattle(int loserID)
    {
        ready = false;
        Text txtGameOver = GameOverScreen.GetComponentInChildren<Text>();

        GameObject.FindGameObjectWithTag(Constants.TAG_HUD).SetActive(false);

        if (localplayer.playerID == loserID)
        {
            txtGameOver.color = Color.red;
            txtGameOver.text = "DEFEAT";
        }

        else
        {
            txtGameOver.color = Color.green;
            txtGameOver.text = "VICTORY";
        }

    }

    void StartBattle()
    {
        Player[] players = FindObjectsOfType<Player>();
        if (players.Length != Constants.MATCH_SIZE)
        {
            //Invokes Ready function after set delay (3s) if not all players are ready.
            Invoke("StartBattle", Constants.WAIT_DELAY);
            return;
        }

        playerList = new List<Player>();

        for (int i = 0; i < players.Length; i++)
        {
            playerList.Add(players[i]);

            //Temporary implementation
            //playerList[i].txtPlayerName.text = "Player " + playerList[i].playerID;

            if (playerList[i].isLocalPlayer)
                localplayer = playerList[i];
            else
                opponent = playerList[i];

        }

        opponent.transform.position = OpponentSpawn.position;
        ready = true;

    }

    public void DamagePlayer(int playerID, int damage)
    {
        if (ready)
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i].playerID != playerID)
                {
                    playerList[i].TakeDamage(damage);
                    
                }

            }
        }

    }

}
