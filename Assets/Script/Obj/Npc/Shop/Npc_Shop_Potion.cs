using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Npc_Shop_Potion : Npc
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Active_Npc()
    {
        Shop.SetActive(true);
        InputManager.Instance.Now_Input_Type = InputManager.INPUT_TYPE.SHOP;
    }

    
    public void Buy_ITem(Item.ITEM_TYPE _Type)
    {
        switch (_Type)
        {
            case Item.ITEM_TYPE.HP_POTION:
                break;
            case Item.ITEM_TYPE.END:
                break;
        }
    }

    public void Hp_Potion_Buy_Button()
    {
        int Count = Int32.Parse(Item_Count.text);
        int Gold = PlayerManager.Instance.Player.GetComponent<Player>().Player_Info.Money;

        if(Count * 100 > Gold)
        {
            Buy_Fail.SetActive(true);
        }
        else
        {
            PlayerManager.Instance.Player.GetComponent<Player>().Plus_Gold(Count * -100);
            PlayerManager.Instance.Inventory_Add_Item(Item.ITEM_TYPE.HP_POTION, Count);
            Buy_Succes.SetActive(true);
        }
    }

    public void Shop_Close()
    {
        InputManager.Instance.Now_Input_Type = InputManager.INPUT_TYPE.NORMAL;
        Shop.SetActive(false);
        Buy_Succes.SetActive(false);
        Buy_Fail.SetActive(false);
    }

    public void Buy_Succes_Button()
    {
        Buy_Succes.SetActive(false);
    }

    public void Buy_Fail_Button()
    {
        Buy_Fail.SetActive(false);
    }

    public InputField Item_Count;
    public GameObject Shop;
    public GameObject Buy_Succes;
    public GameObject Buy_Fail;
    
}
