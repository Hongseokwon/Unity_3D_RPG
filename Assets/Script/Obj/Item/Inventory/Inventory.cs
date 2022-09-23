using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{


    public Inventory()
    {
        Item_List = new List<Item>();
    }

    public Inventory(Inventory _Temp)
    {
        Item_List = new List<Item>();
        for(int i=0; i<_Temp.Item_List.Count;++i)
        {
            switch (_Temp.Item_List[i].Item_Type)
            {
                case Item.ITEM_TYPE.HP_POTION:
                    Item_List.Add(new Item_Hp_Potion(_Temp.Item_List[i].Count));
                    break;
                case Item.ITEM_TYPE.END:
                    break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Add_Item(Item.ITEM_TYPE _Type, int _Count)
    {
        for (int i = 0; i < Item_List.Count; ++i)
        {
            if (Item_List[i].Item_Type == _Type)
            {
                Item_List[i].Count += _Count;
                return;
            }
        }
        switch (_Type)
        {
            case Item.ITEM_TYPE.HP_POTION:
                Item_List.Add(new Item_Hp_Potion(_Count));
                break;
            case Item.ITEM_TYPE.END:
                break;
        }
        
    }

    public int Item_Count(Item.ITEM_TYPE _Item_Type)
    {
        int Cnt = 0;

        for(int i=0; i<Item_List.Count;++i)
        {
            if (Item_List[i].Item_Type == _Item_Type)
                Cnt += Item_List[i].Count;
        }

        return Cnt;
    }

    public void Use_Item(Item.ITEM_TYPE _Item_Type)
    {
        for (int i = 0; i < Item_List.Count; ++i)
        {
            if (Item_List[i].Item_Type == _Item_Type)
                Item_List[i].Use_Item();
        }
    }

    public List<Item> Item_List ;
}
