using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Village_To_HuntingGround : Portal
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Active_Npc()
    {
        Set_Player();
        MySceneManager.Instance.Change_Scene(MySceneManager.SCENE_LIST.HUNTING_GROUND);
    }

    public override void Set_Player()
    {
        PlayerManager.Instance.Player_Info_Save();
        GameManager.Instance.Player_SD.Player_Pos = new Vector3(3f, 0f, 10f);
    }
}
