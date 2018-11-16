using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory {

    private int inventoryID;
    private List<Item> inventoryItems;

    public PlayerInventory()
    {
        inventoryItems = new List<Item>();
    }

    public int InventoryID
    {
        get { return inventoryID; }
        set { inventoryID = value; }
    }

    public List<Item> InventoryItems
    {
        get { return inventoryItems; }
        set { inventoryItems = value; }
    }


    public List<Item> GetWeapons()
    {
        List<Item> WeaponsList = new List<Item>();
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            Item item = inventoryItems[i];
            if (item.Category.CategoryID == Constants.CATEGORY_WEAPON)
            {
                WeaponsList.Add(item);
            }

        }

        return WeaponsList;

    }

    public List<Item> GetArmour()
    {
        List<Item> ArmourList = new List<Item>();
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            Item item = inventoryItems[i];
            if (item.Category.CategoryID == Constants.CATEGORY_ARMOUR)
            {
                ArmourList.Add(item);
            }

        }

        return ArmourList;

    }

}
