using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public void Update()
    {
        if (My_Monster_Manager != null)
            My_Monster_Manager.Update();

        if (My_Npc_Manager != null)
            My_Npc_Manager.Update();
    }

    public void Map_Load()
    {
        if (My_Monster_Manager != null)
            My_Monster_Manager.Monster_Load();

        if (My_Npc_Manager != null)
            My_Npc_Manager.Npc_Load();
    }

    public void Monster_Dead(int _Num)
    {
        My_Monster_Manager.Monster_Dead(_Num);
    }

    protected MonsterManager My_Monster_Manager;
    protected NPCManager My_Npc_Manager;
}
