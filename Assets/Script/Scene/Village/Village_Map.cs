using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village_Map : Map
{
    public Village_Map()
    {
        My_Monster_Manager = null;
        My_Npc_Manager = new Village_NPC_Manager();
    }

}
