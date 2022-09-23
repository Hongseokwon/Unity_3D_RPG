using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunting_Ground_UI_Manager : UI_Manager
{
    private static Hunting_Ground_UI_Manager instance = null;

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

    public static Hunting_Ground_UI_Manager Instance
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
        PlayerManager.Instance.Create_Player();
        PlayerManager.Instance.Player_Set();
        Hunting_Ground_Camera_Manager.Instance.Camera_Set();
        MapManager.Instance.Map_Load();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LateUpdate()
    {
        UI_Set();
    }

    public void Save_Button()
    {
        GameManager.Instance.Save_Data();
    }

    public void Quit_Button()
    {
        MySceneManager.Instance.Change_Scene(MySceneManager.SCENE_LIST.GAME_START);
    }

}
