using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager
{
    public struct Monster_Info
    {
        public Monster_Info(Vector3 _Pos, int _Num, bool _Dead = false)
        {
            Pos = _Pos;
            Num = _Num;
            Dead = _Dead;
        }
        public Vector3 Pos;
        public int Num;
        public bool Dead;

    }

    public void Update()
    {
        Monster_Respawn_Time_Check();
    }

    public virtual void Monster_Load() { }

    protected virtual void Monster_Respawn() { }

    public void Monster_Respawn_Time_Check()
    {
        Respawn_Timer += Time.deltaTime;
        if (Respawn_Timer > Respawn_Time)
        {
            Monster_Respawn();
            Respawn_Timer = 0f;
        }
    }

    public void Monster_Dead(int _Num)
    {
        Monster_List[_Num] = new Monster_Info(Monster_List[_Num].Pos, Monster_List[_Num].Num, true);
    }

    protected int Monster_Num;


    protected List<Monster_Info> Monster_List;
    protected List<Vector3> Monster_Pos_List;

    protected float Respawn_Timer;
    protected float Respawn_Time;
}
