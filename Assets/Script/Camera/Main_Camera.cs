using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = Player.position + Offset;
    }

    public void Camera_Set()
    {
        Player = PlayerManager.Instance.Player.transform;
        Offset = new Vector3(0f, 5f, -2.5f);
        transform.rotation = Quaternion.Euler(60f, 0f, 0f);
    }

    public Transform Player;

    Vector3 Offset;
}
