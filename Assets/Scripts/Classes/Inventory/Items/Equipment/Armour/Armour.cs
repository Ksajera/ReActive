using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armour : Item {

    private bool equipped;
    private int armourAmount;

    public bool Equipped
    {
        get { return equipped; }
        set { equipped = value; }
    }
    public int ArmourAmount
    {
        get { return armourAmount; }
        set { armourAmount = value; }
    }

    public Armour(int ItemID, ItemCategory category, string itemDesc, bool equipped, int armourAmt) : base(ItemID, category, itemDesc)
    {
        this.equipped = equipped;
        this.armourAmount = armourAmt;
    }
}
