using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingEquip : MonoBehaviour
{

    public int uid = 1;

    PlayerEquipment equipment;
    PlayerInventory inventory;

    public GameObject armourGO;
    public GameObject wepGO;
    public GameObject btnEquip;
    public GameObject equipedRight;
    private SpriteRenderer SRequipedRight;

    public Sprite armour1;
    public Sprite armour2;
    public Sprite armour3;
    public Sprite wep1;
    public Sprite wep2;
    public Sprite wep3;

    public Sprite armourSprite;
    public Sprite wepSprite;

    public Sprite selectedSprite;

    void Awake()
    {

        equipment = GameManager.singleton.equipment;
        inventory = GameManager.singleton.inventory;

        try
        {
            whichUser();
            print(armourSprite.name);

        }
        catch
        {
            SRequipedRight = equipedRight.GetComponent<SpriteRenderer>();
            print("FAIL");
            armourSprite = armour1;
            wepSprite = wep1;
        }

        SpriteRenderer ago = armourGO.GetComponent<SpriteRenderer>();
        SpriteRenderer wgo = wepGO.GetComponent<SpriteRenderer>();
        ago.sprite = armourSprite;
        wgo.sprite = wepSprite;
        btnEquip.SetActive(false);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //touchItem();
        touchItem2();
    }

    //void OnMouseDown()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        btnEquip.SetActive(true);
    //        selectedSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    //        print(selectedSprite.name);
    //    }
    //}

    void whichUser()
    {
        if (uid == 1)
        {
            armourSprite = armour1;
            wepSprite = wep1;
        }
        else if (uid == 2)
        {
            armourSprite = armour2;
            wepSprite = wep2;
        }
        else if (uid == 3)
        {
            armourSprite = armour3;
            wepSprite = wep3;
        }
    }

    public void onClickEquipthis()
    {
        //equip sprites
        SRequipedRight.sprite = selectedSprite;
        print(SRequipedRight.sprite.name);
        if (SRequipedRight.sprite.name == "weaponSprite1")
        {
            if (equipment.wep != null)
            {
                equipment.wep.Equipped = false;
            }
            equipment.wep = new Weapon(5, GameManager.singleton.CategoryWeapon, "", true, 20);
            calcDmg();
            print("Attack = " + GameManager.singleton.stats.Attack);
        }

        else if (SRequipedRight.sprite.name == "armourSprite1")
        {
            if (equipment.armour != null)
            {
                equipment.armour.Equipped = false;
            }
            equipment.armour = new Armour(5, GameManager.singleton.CategoryArmour, "", true, 5);
            calcArmour();
            print("Def = " + GameManager.singleton.stats.Defense);
        }
    }

    void calcDmg()
    {
        GameManager.singleton.stats.Attack = Constants.PLAYER_ATTACK + equipment.wep.DamageAmount;
    }
    void calcArmour()
    {
        GameManager.singleton.stats.Defense = Constants.PLAYER_DEFENSE + equipment.armour.ArmourAmount;
    }

    void touchItem()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
                // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
                print("upupup");
                if (hitInfo)
                {
                    print("upshit");
                    if (hitInfo.transform.gameObject.tag == "item")
                    {
                        print("shit");
                        btnEquip.SetActive(true);
                        selectedSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
                        print(selectedSprite.name);
                    }
                    if (hitInfo.transform.gameObject.tag == "equipItem")
                    {
                        onClickEquipthis();
                    }
                    Debug.Log(hitInfo.transform.gameObject.name);
                    // Here you can check hitInfo to see which collider has been hit, and act appropriately.
                }
            }
        }
    }
    void touchItem2()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);                // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
            print("upupup");
                if (hitInfo)
                {
                    print("upshit");
                    if (hitInfo.transform.gameObject.tag == "item")
                    {
                        print("shit");
                        btnEquip.SetActive(true);
                        selectedSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
                        print(selectedSprite.name);
                    }
                    if (hitInfo.transform.gameObject.tag == "equipItem")
                    {
                        onClickEquipthis();
                    }
                    Debug.Log(hitInfo.transform.gameObject.name);
                    // Here you can check hitInfo to see which collider has been hit, and act appropriately.
                }
            }
        }
    
}
