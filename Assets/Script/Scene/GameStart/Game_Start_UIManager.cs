using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Start_UIManager : MonoBehaviour
{
    private static Game_Start_UIManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static Game_Start_UIManager Instance
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

    public void Game_Start_Button()
    {
        Obj.OBJ_INFO Temp_Info = new Obj.OBJ_INFO(1, 100, 100, 5, 8, 1, false, "Hong");

        Player.PLAYER_INFO Temp_Player_Info = new Player.PLAYER_INFO("Hong", 0, 100, 100);

        GameManager.Instance.Player_SD.Save_Obj_Info = Temp_Info;
        GameManager.Instance.Player_SD.Save_Player_Info = Temp_Player_Info;
        GameManager.Instance.Player_SD.Save_Inventory = new Inventory();
        GameManager.Instance.Player_SD.Player_Pos = new Vector3(5f, 0f, 5f);

        MySceneManager.Instance.Change_Scene(MySceneManager.SCENE_LIST.VILLAGE);
    }

    public void Game_Load_Button()
    {
        Load_Fail.SetActive(true);
    }

    public void Data_Load_Fail_Button()
    {
        Load_Fail.SetActive(false);
    }

    public GameObject Load_Fail;
}
