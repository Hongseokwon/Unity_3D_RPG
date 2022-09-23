using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    private static MySceneManager instance = null;

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

    public static MySceneManager Instance
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

    public enum SCENE_LIST
    {
        GAME_START = 0,
        VILLAGE = 100,
        HUNTING_GROUND = 200
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Change_Scene(SCENE_LIST _New_Scene)
    {
        if (Cur_Scene == _New_Scene)
            return;

        switch (_New_Scene)
        {
            case SCENE_LIST.GAME_START:
                Game_Start_Scene();
                break;
            case SCENE_LIST.VILLAGE:
                Village_Scene();
                break;
            case SCENE_LIST.HUNTING_GROUND:
                Hunting_Ground_Scene();
                break;
        }

        Cur_Scene = _New_Scene;
    }

    public void Game_Start_Scene()
    {
        MapManager.Instance.Change_Map(SCENE_LIST.GAME_START);
        InputManager.Instance.Now_Input_Type = InputManager.INPUT_TYPE.END;
        SceneManager.LoadScene("GameStart");
    }

    public void Village_Scene()
    {
        MapManager.Instance.Change_Map(SCENE_LIST.VILLAGE);
        InputManager.Instance.Now_Input_Type = InputManager.INPUT_TYPE.NORMAL;
        SceneManager.LoadScene("Village");
    }

    public void Hunting_Ground_Scene()
    {
        MapManager.Instance.Change_Map(SCENE_LIST.HUNTING_GROUND);
        InputManager.Instance.Now_Input_Type = InputManager.INPUT_TYPE.NORMAL;
        SceneManager.LoadScene("Hunting Ground");
    }


    SCENE_LIST Cur_Scene;
}
