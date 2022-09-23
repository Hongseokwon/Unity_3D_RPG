using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Obj
{
    public Player()
    {
        Angle_Per_Second = 360f;
        Move_Speed = 2f;
        Attack_Delay = 2f;
        Attack_Timer = 0f;
        Attack_Dis = 1.5f;
        Chase_Dis = 2.5f;
        Npc_Dis = 1.5f;

        Cur_Target_Monster = null;
        Cur_Target_Npc = null;
        Cur_State = Player_State.IDLE;

        Dead_Event.AddListener(Player_Dead);

    }

    public struct PLAYER_INFO
    {
        public PLAYER_INFO(string _Name , int _Exp, int _Exp_Max, int _Money)
        {
            Name = _Name;
            Exp = _Exp;
            Exp_Max = _Exp_Max;
            Money = _Money;
        }

        public string Name { get; set; }
        public int Exp { get; set; }
        public int Exp_Max { get; set; }
        public int Money { get; set; }
    }

    public enum Player_State
    {
        IDLE, MOVE, ATTACK, ATTACK_WAIT, DEAD, END
    }

    // Start is called before the first frame update
    void Start()
    {
        Player_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Update_State();
    }

    public void Change_State(Player_State _State)
    {
        if (Cur_State == _State)
            return;

        Player_Animator.SetInteger("State", (int)_State);
        Cur_State = _State;
    }

    private void Update_State()
    {
        switch (Cur_State)
        {
            case Player_State.IDLE:
                Idle_State();
                break;
            case Player_State.MOVE:
                Move_State();
                break;
            case Player_State.ATTACK:
                Attack_State();
                break;
            case Player_State.ATTACK_WAIT:
                Attack_Wait_State();
                break;
            case Player_State.DEAD:
                Dead_State();
                break;
            case Player_State.END:
                break;
        }
    }

    public void Move_To(Vector3 _Pos)
    {
        if (Cur_State == Player_State.DEAD)
            return;
        Cur_Target_Monster = null;
        Cur_Target_Npc = null;
        Cur_Target_Pos = _Pos;
        Change_State(Player_State.MOVE);
    }

    private void Turn_To_Destination()
    {
        Quaternion Look_Rotation = Quaternion.LookRotation(Cur_Target_Pos - transform.position);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Look_Rotation, Time.deltaTime * Angle_Per_Second);
    }

    private void Move_To_Destination()
    {
        transform.position = Vector3.MoveTowards(transform.position, Cur_Target_Pos, Move_Speed * Time.deltaTime);

        if (Cur_Target_Npc != null)
        {
            if (Vector3.Distance(transform.position, Cur_Target_Pos) < Npc_Dis)
            {
                Cur_Target_Npc.GetComponent<Npc>().Active_Npc();
                Cur_Target_Npc = null;
                Change_State(Player_State.IDLE);
            }
        }
        else if (Cur_Target_Monster != null)
        {
            if (Vector3.Distance(transform.position, Cur_Target_Pos) < Attack_Dis)
                Change_State(Player_State.ATTACK);
        }
        else
        {
            if (transform.position == Cur_Target_Pos)
                Change_State(Player_State.IDLE);
        }
    }

    private void Idle_State()
    {

    }

    private void Move_State()
    {
        Turn_To_Destination();
        Move_To_Destination();
    }

    private void Attack_State()
    {
        Attack_Start();
    }

    private void Attack_Wait_State()
    {
        Attack_Wait();
    }

    private void Dead_State()
    {

    }

    public void Attack_Target(GameObject _Monster)
    {
        if (Cur_Target_Monster == _Monster)
            return;


        if (_Monster.GetComponent<Monster>().Info.Is_Dead)
        {
            Cur_Target_Monster = null;
        }
        else
        {
            Cur_Target_Npc = null;
            Cur_Target_Monster = _Monster;
            Cur_Target_Pos = Cur_Target_Monster.transform.position;

            Change_State(Player_State.MOVE);
        }
    }

    private void Attack_Start()
    {
        Attack_Timer = 0f;

        transform.LookAt(Cur_Target_Pos);
        Change_State(Player_State.ATTACK_WAIT);
    }

    private void Attack_Wait()
    {
        if (Attack_Timer > Attack_Delay)
        {
            Change_State(Player_State.ATTACK);
        }

        Attack_Timer += Time.deltaTime;
    }

    public void Monster_Attack()
    {
        if (Cur_Target_Monster == null)
            return;

        Cur_Target_Monster.GetComponent<Monster_Spider>().Show_Hit_Effect();

        Cur_Target_Monster.GetComponent<Monster_Spider>().Attacked_By_Enemy(Get_Random_Attack());
    }

    public void Set_Player()
    {
        Player_Info.Name = "Hong";
        Info.Level = 1;
        Info.HP_Max = 100;
        Info.HP = Info.HP_Max;
        Info.Attack_Min = 5;
        Info.Attack_Max = 8;
        Info.Defense = 1;

        Player_Info.Exp = 0;
        Player_Info.Exp_Max = 100 * Info.Level;
        Player_Info.Money = 0;

        //UI_Manager.Instance.Update_Player_UI(Info, Player_Info);
    }

    protected override void Dead_Check()
    {
        print(name + "s HP:" + Info.HP);

        if (Info.HP <= 0)
        {
            Info.HP = 0;
            Info.Is_Dead = true;
            Dead_Event.Invoke();
        }

        //UI_Manager.Instance.Update_Player_UI(Info, Player_Info);
    }

    public void Currnet_Enemy_Dead()
    {
        Change_State(Player_State.IDLE);

        Cur_Target_Monster = null;
    }

    public void Player_Dead()
    {
        Change_State(Player_State.DEAD);
    }

    public void Monster_Reward(int _Exp, int _Money)
    {
        Player_Info.Exp += _Exp;
        Debug.Log(Player_Info.Exp);
        Player_Info.Money += _Money;

        //UI_Manager.Instance.Update_Player_UI(Info, Player_Info);

        if (Player_Info.Exp >= Player_Info.Exp_Max)
        {
            Level_Up();
        }
    }

    private void Level_Up()
    {
        Player_Info.Exp -= Player_Info.Exp_Max;

        Info.Level++;

        Player_Info.Exp_Max = 100 * Info.Level;
        Info.HP_Max = 90 + 10 * Info.Level;
        Info.HP = Info.HP_Max;

        //UI_Manager.Instance.Update_Player_UI(Info, Player_Info);
    }

    public void Plus_Gold(int _Gold)
    {
        Player_Info.Money += _Gold;
    }

    public void Npc_Target(GameObject _Npc)
    {
        if (Cur_Target_Npc == _Npc)
            return;

        Cur_Target_Monster = null;
        Cur_Target_Npc = _Npc;
        Cur_Target_Pos = Cur_Target_Npc.transform.position;

        Change_State(Player_State.MOVE);
    }

    public int Get_Inventory_Item_Count(Item.ITEM_TYPE _Item_Type)
    {
        return My_Inventory.Item_Count(_Item_Type);
    }

    public void Use_Item(Item.ITEM_TYPE _Item_Type)
    {
        My_Inventory.Use_Item(_Item_Type);
    }

    public void Plus_Hp(int _Hp)
    {
        Info.HP += _Hp;

        if (Info.HP > Info.HP_Max)
            Info.HP = Info.HP_Max;

        if (Info.HP < 0)
            Info.HP = 0;
    }

    private float Angle_Per_Second;
    private float Move_Speed;
    private float Attack_Delay;
    private float Attack_Timer;
    private float Attack_Dis;
    private float Chase_Dis;
    private float Npc_Dis;

    private GameObject Cur_Target_Monster;
    private GameObject Cur_Target_Npc;

    private Vector3 Cur_Target_Pos;

    public Player_State Cur_State;
    public Animator Player_Animator;

    public PLAYER_INFO Player_Info;

    public Inventory My_Inventory;
}
