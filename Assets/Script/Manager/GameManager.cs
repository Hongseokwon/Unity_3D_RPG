using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager()
    {
        Player_SD = new Player_Save_Data();

        Game_Data_File_Name = "Player_Info_Data";
    }

    private static GameManager instance = null;

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

    public static GameManager Instance
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
        Test();
    }
    
    public void Load_Data()
    {
        string File_Path = Application.persistentDataPath + Game_Data_File_Name;

        if(File.Exists(File_Path))
        {
            string From_Json__Data = File.ReadAllText(File_Path);
            Player_SD = JsonUtility.FromJson<Player_Save_Data>(From_Json__Data);
        }
        else
        {

        }
    }

    public void Save_Data()
    {
        PlayerManager.Instance.Player_Info_Save();
        string To_Json_Data = JsonUtility.ToJson(Player_SD);
        string File_Path = Application.persistentDataPath + Game_Data_File_Name;

        File.WriteAllText(File_Path, To_Json_Data);
    }


    private void Test()
    {
 
    }


    public Player_Save_Data Player_SD;

    public string Game_Data_File_Name;
}
