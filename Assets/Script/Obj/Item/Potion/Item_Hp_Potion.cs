using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Hp_Potion : Item
{
    public Item_Hp_Potion(int _Count)
    {
        Item_Type = ITEM_TYPE.HP_POTION;
        Count = _Count;
        HP = 50;
    }
    public override void Use_Item()
    {
        if (Count > 0)
        {
            Count--;
            PlayerManager.Instance.Player.GetComponent<Player>().Plus_Hp(HP);
        }
    }

    public override void Sell_Item()
    {

    }

    public override void Buy_Item()
    {

    }

    int HP;
}
