using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ITEM_TYPE
    {
        HP_POTION,
        END
    }

    public virtual void Use_Item() { }

    public virtual void Sell_Item() { }

    public virtual void Buy_Item() { }

    public ITEM_TYPE Item_Type { get; set; }
    public int Count { get; set; }
}
