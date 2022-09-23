using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunting_Ground_Camera_Manager : CameraManager
{
    private static Hunting_Ground_Camera_Manager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static Hunting_Ground_Camera_Manager Instance
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

    public void Camera_Set()
    {
        Player_Camera.GetComponent<Main_Camera>().Camera_Set();
    }

    public GameObject Player_Camera;
}
