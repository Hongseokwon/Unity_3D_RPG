using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunting_Ground_Monster_Manager : MonsterManager
{
    public Hunting_Ground_Monster_Manager()
    {
        Monster_List = new List<Monster_Info>();

        Monster_Num = 4;

        Monster_Pos_List = new List<Vector3>(new Vector3[Monster_Num]);

        Respawn_Time = 10f;
        Respawn_Timer = 0f;

        Monster_Pos_List[0] = new Vector3(5f, 0f, 5f);
        Monster_Pos_List[1] = new Vector3(5f, 0f, 10f);
        Monster_Pos_List[2] = new Vector3(10f, 0f, 5f);
        Monster_Pos_List[3] = new Vector3(10f, 0f, 10f);
    }

    public override void Monster_Load()
    {
        for (int i = 0; i < Monster_Num; ++i)
        {
            Monster_List.Add(new Monster_Info(Monster_Pos_List[i], i));

            PrefabManager.Instance.Create_Monster_Spider(Monster_Pos_List[i], i);
        }
    }

    protected override void Monster_Respawn()
    {
        for (int i = 0; i < Monster_List.Count; ++i)
        {
            if (Monster_List[i].Dead)
            {
                PrefabManager.Instance.Create_Monster_Spider(Monster_List[i].Pos, Monster_List[i].Num);
                Monster_List[i] = new Monster_Info(Monster_List[i].Pos, Monster_List[i].Num);
            }
        }
    }
}
