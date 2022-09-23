using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Village_UI_Manager : UI_Manager
{
    private static Village_UI_Manager instance = null;

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

    public static Village_UI_Manager Instance
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
        Village_CameraManager.Instance.Camera_Set();
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
