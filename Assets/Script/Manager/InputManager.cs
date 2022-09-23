using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public enum INPUT_TYPE
    {
        NORMAL, SHOP, END
    }

    private static InputManager instance = null;

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

    public static InputManager Instance
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

    public InputManager()
    {
        Now_Input_Type = INPUT_TYPE.END;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Input_Check();
    }

    private void Input_Check()
    {
        switch (Now_Input_Type)
        {
            case INPUT_TYPE.NORMAL:
                Mouse_Check();
                Keyboard_Check();
                break;
            case INPUT_TYPE.SHOP:
                break;
            case INPUT_TYPE.END:
                break;
        }
    }
    private void Mouse_Check()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                string Temp = hit.collider.gameObject.tag;
                if (Temp == "Terrain")
                {
                    PlayerManager.Instance.Player.GetComponent<Player>().Move_To(hit.point);
                }
                else if (Temp == "Portal" || Temp == "NPC")
                {
                    PlayerManager.Instance.Player.GetComponent<Player>().Npc_Target(hit.collider.gameObject);
                }
                else if (Temp == "Monster")
                {
                    PlayerManager.Instance.Player.GetComponent<Player>().Attack_Target(hit.collider.gameObject);
                }
            }
        }
    }

    private void Keyboard_Check()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("111");
            PlayerManager.Instance.Player.GetComponent<Player>().Use_Item(Item.ITEM_TYPE.HP_POTION);
        }
    }
    

    public INPUT_TYPE Now_Input_Type;
}

