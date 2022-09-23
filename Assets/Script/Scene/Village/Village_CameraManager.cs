using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village_CameraManager : CameraManager
{
    private static Village_CameraManager instance = null;

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

    public static Village_CameraManager Instance
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
