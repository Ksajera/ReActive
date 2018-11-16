using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats {

    public int maxHealth;
    //private int currentHealth;
    public int attack;
    public int defense;
    public int level;

    //PlayerInventory inventory;
    //PlayerEquipment equipment;

    //int CountEquippedWep;
    //int CountEquippedArmour;

    //void Awake()
    //{
    //    inventory = GameManager.singleton.inventory;
    //    equipment = GameManager.singleton.equipment;
        
    //    equipment.Inventory = inventory;

    //    CountEquippedWep = 0;
    //    CountEquippedArmour = 0;
    //}

    //Default Constructor
    public PlayerStats()
    {
        maxHealth = Constants.PLAYER_HEALTH_MAX;

        attack = Constants.PLAYER_ATTACK;
        defense = Constants.PLAYER_DEFENSE;
        level = Constants.PLAYER_STARTING_LEVEL;
        //currentHealth = maxHealth;    
        //foreach (Weapon w in equipment.Inventory.GetWeapons())
        //{
        //    if (w.Equipped == true)
        //    {
        //        CountEquippedWep++;
        //    }
        //}
        //foreach (Armour a in equipment.Inventory.GetArmour())
        //{
        //    if (a.Equipped == true)
        //    {
        //        CountEquippedArmour++;
        //    }
        //}
        //if (CountEquippedWep > 0)
        //{
        //    attack = Constants.PLAYER_ATTACK + equipment.IncreaseAttack();
        //}
        //else
        //{
        //    attack = Constants.PLAYER_ATTACK;
        //}
        //if (CountEquippedArmour > 0)
        //{
        //    defense = Constants.PLAYER_DEFENSE + equipment.IncreaseArmour();
        //}
        //else
        //{
        //    defense = Constants.PLAYER_DEFENSE;
        //}

    }

    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    //public int CurrentHealth
    //{
    //    get { return currentHealth; }
    //    set { currentHealth = value; }
    //}

    public int Attack
    {
        get { return attack; }
        set { attack = value; }
    }

    public int Defense
    {
        get { return defense; }
        set { defense = value; }
    }

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    //on change equipment
    //void AddAttack()
    //{
    //    attack += equipment.IncreaseAttack();
    //}

    //void AddDefense()
    //{
    //    defense += equipment.IncreaseArmour();
    //}

}
