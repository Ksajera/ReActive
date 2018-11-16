using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : NetworkBehaviour {

    PlayerStats stats;
    PlayerInventory inventory;
    PlayerEquipment equipment;

    public Text txtPlayerName;

    private int playerDamage;
    private int playerDefense;

    [SyncVar]
    public int playerID;

    [SyncVar(hook = "OnHPChange")]
    public int HP;
    public int MaxHP;

    void Awake()
    {
        stats = GameManager.singleton.stats;

        inventory = GameManager.singleton.inventory;
        equipment = GameManager.singleton.equipment;

        equipment.Inventory = inventory;

        stats.Attack += equipment.CalculateAttack();
        stats.Defense += equipment.CalculateDefense();

    }

    // Use this for initialization
    void Start () {
        if (stats == null)
            stats = new PlayerStats();

        if (inventory == null)
            inventory = new PlayerInventory();

        if (equipment == null)
            equipment = new PlayerEquipment();

        HP = stats.MaxHealth;
        MaxHP = stats.MaxHealth;

        playerDamage = stats.Attack;
        playerDefense = stats.Defense;

        txtPlayerName = GetComponent<Text>();

	}

    void OnHPChange(int newHP)
    {
        HP = newHP;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Player " + playerID + " is under Attack!");

        if (HP <= 0)
        {
            Debug.Log("Player " + playerID + " has been defeated!");
            return;
        }

        else if (HP > 0)
            HP -= Mathf.Clamp((damage - playerDefense), 0, HP);

        Debug.Log("Player " + playerID + " HP: " + HP);

    }

    [Command]
    public void CmdAttack()
    {
        Debug.Log("Player " + playerID + " is Attacking!");
        BattleManager.singleton.DamagePlayer(playerID, playerDamage);

    }

}
