using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCategory {

    private int categoryID;
    private string categoryName;
    private string categoryDescription;

    public ItemCategory(int _categoryID, string _categoryName, string _categoryDescription)
    {
        this.categoryID = _categoryID;
        this.categoryName = _categoryName;
        this.categoryDescription = _categoryDescription;

    }

    public int CategoryID
    {
        get { return categoryID; }
        set { categoryID = value; }
    }

    public string CategoryName
    {
        get { return categoryName; }
        set { categoryName = value; }
    }

    public string CategoryDescription
    {
        get { return categoryDescription; }
        set { categoryDescription = value; }
    }


}
