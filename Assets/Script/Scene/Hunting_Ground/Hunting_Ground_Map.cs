using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunting_Ground_Map : Map
{

    public Hunting_Ground_Map()
    {
        My_Monster_Manager = new Hunting_Ground_Monster_Manager();
        My_Npc_Manager = null;
    }

}
