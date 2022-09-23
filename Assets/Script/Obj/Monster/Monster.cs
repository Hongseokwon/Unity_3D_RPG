using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : Obj
{
    public struct MONSTER_INFO
    {
        public string Name;
        public int Exp { get; set; }
        public int Reward_Money { get; set; }
    }

    public enum Monster_State
    {
        IDLE, CHASE, ATTACK, DEAD, NOSTATE, END
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Set_Monster(int _Num)
    {
    }

    public Monster_State Cur_State;

    protected float Chase_Dis;
    protected float Attack_Dis;
    protected float Re_Chase_Dis;

    protected float Angle_Per_Sec;
    protected float Move_Speed;

    protected float Attack_Delay;
    protected float Attack_Timer;

    protected int Monster_Num;

    public MONSTER_INFO Monster_Info;

    public Image Hp_Bar;
}
