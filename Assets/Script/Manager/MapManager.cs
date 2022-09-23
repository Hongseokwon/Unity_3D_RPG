using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private static MapManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);

            DontDestroyOnLoad(this.gameObject);
        }
    }

    public static MapManager Instance
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
        if (Now_Map != null)
            Now_Map.Update();
    }

    public void Change_Map(MySceneManager.SCENE_LIST _Scene)
    {
        switch (_Scene)
        {
            case MySceneManager.SCENE_LIST.GAME_START:
                Change_Map_Game_Start();
                break;
            case MySceneManager.SCENE_LIST.VILLAGE:
                Change_Map_Village();
                break;
            case MySceneManager.SCENE_LIST.HUNTING_GROUND:
                Change_Map_Hunting_Ground();
                break;
        }
    }

    public void Map_Load()
    {
        Now_Map.Map_Load();
    }

    private void Change_Map_Game_Start()
    {
        Now_Map = null;
    }

    private void Change_Map_Village()
    {
        Now_Map = new Village_Map();
    }

    private void Change_Map_Hunting_Ground()
    {
        Now_Map = new Hunting_Ground_Map();
    }

    public void Monster_Dead(int _Num)
    {
        Now_Map.Monster_Dead(_Num);
    }

    private Map Now_Map;
}
