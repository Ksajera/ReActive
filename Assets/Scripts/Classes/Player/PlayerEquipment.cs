using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment {

    public PlayerInventory Inventory { get; set; }

    public int Attack = 0;
    public int Armour = 0;

    public Weapon wep;
    public Armour armour;

    public int CalculateAttack()
    {
        foreach (Weapon w in Inventory.GetWeapons())
        {
            if (w.Equipped == true)
            {
                wep = w;
                Attack = w.DamageAmount;
                break;
            }
        }
        return Attack;

    }

    public int CalculateDefense()
    {
        foreach (Armour a in Inventory.GetArmour())
        {
            if (a.Equipped == true)
            {
                armour = a;
                Armour += a.ArmourAmount;
            }
        }

        return Armour;

    }

    //public int IncreaseAttack()
    //{
    //    foreach(Weapon w in Inventory.GetWeapons())
    //    {
    //        if(w.Equipped == true)
    //        {
    //            Attack += w.DamageAmount;
    //        }
    //    }
    //    return Attack;
    //}

    //public int IncreaseArmour()
    //{
    //    foreach(Armour a in Inventory.GetArmour())
    //    {
    //        if(a.Equipped == true)
    //        {
    //            Armour += a.ArmourAmount;
    //        }
    //    }
    //    return Armour;
    //}


}
