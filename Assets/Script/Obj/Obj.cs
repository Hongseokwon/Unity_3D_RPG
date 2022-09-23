using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obj : MonoBehaviour
{
    public struct OBJ_INFO
    {
        public OBJ_INFO(int _Level, int _HP_Max , int _HP , int _Attack_Min , int _Attack_Max, int _Defense, bool _Is_Dead , string _Name)
        {
            Level = _Level;
            HP_Max = _HP_Max;
            HP = _HP;
            Attack_Min = _Attack_Min;
            Attack_Max = _Attack_Max;
            Defense = _Defense;
            Is_Dead = _Is_Dead;
            name = _Name;
        }

        public int Level { get; set; }
        public int HP_Max { get; set; }
        public int HP { get; set; }
        public int Attack_Min { get; set; }
        public int Attack_Max { get; set; }
        public int Defense { get; set; }
        public bool Is_Dead { get; set; }

        public string name;
    }

    public Obj()
    {
        Dead_Event = new UnityEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Get_Random_Attack()
    {
        int Rand_Attack = Random.Range(Info.Attack_Min, Info.Attack_Max + 1);

        return Rand_Attack;
    }

    public void Attacked_By_Enemy(int _Attack_Power)
    {
        Info.HP -= _Attack_Power;

        Dead_Check();
    }

    protected virtual void Dead_Check() { }

    public OBJ_INFO Info;

    [System.NonSerialized]
    public UnityEvent Dead_Event;
}
