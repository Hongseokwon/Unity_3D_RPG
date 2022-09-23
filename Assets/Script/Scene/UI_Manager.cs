using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void Update_Player_UI(Player.OBJ_INFO _Info, Player.PLAYER_INFO _Player_Info)
    {
        Player_Name_Text.text = _Player_Info.Name;
        Player_Money_Text.text = "Coin : " + _Player_Info.Money.ToString();
        Player_Hp_Image.rectTransform.localScale = new Vector3((float)_Info.HP / (float)_Info.HP_Max, 1f, 1f);
        Player_LV_Text.text = "LV : " + _Info.Level;
        Player_Hp_Text.text = _Info.HP.ToString() + "/" + _Info.HP_Max.ToString();

        Potion_Count.text = PlayerManager.Instance.Player.GetComponent<Player>().Get_Inventory_Item_Count(Item.ITEM_TYPE.HP_POTION).ToString();
    }

    protected void UI_Set()
    {
        Update_Player_UI(PlayerManager.Instance.Player.GetComponent<Player>().Info, PlayerManager.Instance.Player.GetComponent<Player>().Player_Info);
    }

    public Text Player_Name_Text;
    public Text Player_LV_Text;
    public Text Player_Money_Text;
    public Image Player_Hp_Image;
    public Text Player_Hp_Text;

    public Text Potion_Count;
}
