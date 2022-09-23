using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static PlayerManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
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

    public void Add_Player(GameObject _Player)
    {
        Player = _Player;
    }

    public void Player_Set()
    {
        Player.GetComponent<Player>().Info = GameManager.Instance.Player_SD.Save_Obj_Info;
        Player.GetComponent<Player>().Player_Info = GameManager.Instance.Player_SD.Save_Player_Info;
        Player.GetComponent<Player>().transform.position = GameManager.Instance.Player_SD.Player_Pos;
        Player.GetComponent<Player>().My_Inventory = GameManager.Instance.Player_SD.Save_Inventory;
        //Player.GetComponent<Player>().My_Inventory = new Inventory(GameManager.Instance.Player_SD.Save_Inventory);
    }

    public void Player_Info_Save()
    {
        GameManager.Instance.Player_SD.Save_Obj_Info = Player.GetComponent<Player>().Info;
        GameManager.Instance.Player_SD.Save_Player_Info = Player.GetComponent<Player>().Player_Info;
        GameManager.Instance.Player_SD.Player_Pos = Player.GetComponent<Player>().transform.position;
        GameManager.Instance.Player_SD.Save_Inventory = Player.GetComponent<Player>().My_Inventory;
        //GameManager.Instance.Player_SD.Save_Inventory = new Inventory(Player.GetComponent<Player>().My_Inventory);
    }

    public void Create_Player()
    {
        Add_Player(PrefabManager.Instance.Create_Player());
    }

    public void Inventory_Add_Item(Item.ITEM_TYPE _Type, int _Count)
    {
        Player.GetComponent<Player>().My_Inventory.Add_Item(_Type, _Count);
    }

    public GameObject Player;

}
