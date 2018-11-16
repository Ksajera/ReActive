using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    private int itemID;
    private ItemCategory category;
    private string itemDescription;
    private double itemValue;


    public int ItemID
    {
        get { return itemID; }
        set { itemID = value; }
    }

    public ItemCategory Category
    {
        get { return category; }
        set { category = value; }
    }

    public string ItemDescription
    {
        get { return itemDescription; }
        set { itemDescription = value; }
    }

    public double ItemValue
    {
        get { return itemValue; }
        set { itemValue = value; }
    }


    public Item()
    {

    }

    public Item(int itemID, ItemCategory category, string itemDesc)
    {
        this.itemID = itemID;
        this.category = category;
        this.itemDescription = itemDesc;
    }

    public Item(int itemID, ItemCategory category, string itemDesc, double itemValue)
    {
        this.itemID = itemID;
        this.category = category;
        this.itemDescription = itemDesc;
        this.itemValue = itemValue;
    }

}
