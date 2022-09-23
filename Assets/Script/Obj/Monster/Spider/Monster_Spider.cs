using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Spider : Monster
{
    Monster_Spider()
    {
        Cur_State = Monster_State.IDLE;

        Chase_Dis = 5f;
        Attack_Dis = 2.5f;
        Re_Chase_Dis = 3f;

        Angle_Per_Sec = 360f;
        Move_Speed = 1.3f;

        Attack_Delay = 2f;
        Attack_Timer = 0f;

        Dead_Event.AddListener(Call_Dead_Event);
    }

    // Start is called before the first frame update
    void Start()
    {
        Player_Transform = PlayerManager.Instance.Player.transform;
        My_Animation = GetComponent<Animation>();
        Change_State(Monster_State.IDLE);
        Hit_Effect.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Update_State();
    }

    public override void Set_Monster(int _Num)
    {
        Monster_Info.Name = "Monster";
        Info.Level = 1;
        Info.HP_Max = 20;
        Info.HP = Info.HP_Max;
        Info.Attack_Min = 2;
        Info.Attack_Max = 5;
        Info.Defense = 1;

        Monster_Info.Exp = 50;
        Monster_Info.Reward_Money = Random.Range(10, 31);

        Info.Is_Dead = false;

        Monster_Num = _Num;

        Hp_Bar.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void Update_State()
    {
        switch (Cur_State)
        {
            case Monster_State.IDLE:
                Idle_State();
                break;
            case Monster_State.CHASE:
                Chase_State();
                break;
            case Monster_State.ATTACK:
                Attack_State();
                break;
            case Monster_State.DEAD:
                Dead_State();
                break;
            case Monster_State.NOSTATE:
                Nostate_State();
                break;
            case Monster_State.END:
                break;
        }
    }

    private void Idle_State()
    {
        if (Get_Dis_From_Player() < Chase_Dis)
        {
            Change_State(Monster_State.CHASE);
        }
    }

    private void Chase_State()
    {
        if (Get_Dis_From_Player() < Attack_Dis)
        {
            Change_State(Monster_State.ATTACK);
        }
        else
        {
            Turn_To_Destination();
            Move_To_Destination();
        }
    }

    private void Attack_State()
    {
        if (Get_Dis_From_Player() > Re_Chase_Dis)
        {
            Attack_Timer = 0f;
            Change_State(Monster_State.CHASE);
        }
        else
        {
            if (Attack_Timer > Attack_Delay)
            {
                transform.LookAt(Player_Transform.position);

                Change_Animation("attack1_new");

                Attack_Timer = 0f;
            }

            Attack_Timer += Time.deltaTime;
        }
    }

    private void Dead_State()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    private void Nostate_State()
    {

    }

    public void Change_State(Monster_State _State)
    {
        if (Cur_State == _State)
            return;

        Cur_State = _State;

        switch (_State)
        {
            case Monster_State.IDLE:
                Change_Animation("idle");
                break;
            case Monster_State.CHASE:
                Change_Animation("walk");
                break;
            case Monster_State.ATTACK:
                Change_Animation("attack1_new");
                break;
            case Monster_State.DEAD:
                Change_Animation("death1");
                break;
            case Monster_State.NOSTATE:
                break;
            case Monster_State.END:
                break;
        }
    }

    private void Turn_To_Destination()
    {
        Quaternion Look_Rotation = Quaternion.LookRotation(Player_Transform.position - transform.position);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Look_Rotation, Time.deltaTime * Angle_Per_Sec);
    }

    private void Move_To_Destination()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player_Transform.position, Move_Speed * Time.deltaTime);
    }

    private float Get_Dis_From_Player()
    {
        float Dis = Vector3.Distance(transform.position, Player_Transform.position);
        return Dis;
    }


    private void Change_Animation(string _Ani_Name)
    {
        My_Animation.CrossFade(_Ani_Name);
    }

    public void Show_Hit_Effect()
    {
        Hit_Effect.Play();
    }

    protected override void Dead_Check()
    {
        if (Info.HP <= 0)
        {
            Info.HP = 0;
            Info.Is_Dead = true;
            Dead_Event.Invoke();
        }

        Hp_Bar.rectTransform.localScale = new Vector3((float)Info.HP / (float)Info.HP_Max, 1f, 1f);
    }

    private void Call_Dead_Event()
    {
        Change_State(Monster_State.DEAD);
        PlayerManager.Instance.Player.GetComponent<Player>().Currnet_Enemy_Dead();
        PlayerManager.Instance.Player.GetComponent<Player>().Monster_Reward(Monster_Info.Exp, Monster_Info.Reward_Money);

        Invoke("Monster_Destroy", 3f);
    }

    private void Monster_Destroy()
    {
        MapManager.Instance.Monster_Dead(Monster_Num);

        Destroy(gameObject);
    }

    public void Attack_Player()
    {
        PlayerManager.Instance.Player.GetComponent<Player>().Attacked_By_Enemy(Get_Random_Attack());
    }

    private Animation My_Animation;

    private Transform Player_Transform;

    public ParticleSystem Hit_Effect;

}
