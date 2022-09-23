using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    private static PrefabManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static PrefabManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Create_Player()
    {
        GameObject New_Player = Instantiate(Player);
        return New_Player;
    }

    public GameObject Create_Monster_Spider(Vector3 _Pos, int _Num)
    {
        GameObject New_Monster = Instantiate(Monster_Spider);
        New_Monster.transform.position = _Pos;
        New_Monster.GetComponent<Monster>().Set_Monster(_Num);

        return New_Monster;
    }


    public GameObject Player;

    public GameObject Monster_Spider;

}
