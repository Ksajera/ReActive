using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon : Item {

    private bool equipped;
    private int damageAmount;

    public bool Equipped
    {
        get { return equipped; }
        set { equipped = value; }
    }
    public int DamageAmount
    {
        get { return damageAmount; }
        set { damageAmount = value; }
    }

    public Weapon(int ItemID, ItemCategory category, string itemDesc, bool equipped, int damageAmt) : base(ItemID, category, itemDesc)
    {
        this.equipped = equipped;
        this.damageAmount = damageAmt;
    }
    
}
