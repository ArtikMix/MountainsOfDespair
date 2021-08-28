using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saving : MonoBehaviour
{
    PlayerMotor motor;
    HealtBar bar;
    Skills skills;
    //Inventory inventory;
    //public Item health;
    //public Item mana;
    //public Item armor;
    //public Item platelegs;
    //public Item helmet;
    //HealtBar HB, Skills SK, PlayerMotor PM, Inventory I
    void Start()
    {
        //inventory = GetComponent<Inventory>();
    }
    public void SavePlayer(HealtBar HB, Skills SK, PlayerMotor PM, Inventory I)
    {
        SaveSystem.SavePlayer(HB, SK, PM, I);
    }

    public void LoadPlayer()
    {
        int i = 0;
        PlayerData data = SaveSystem.LoadPlayer();
        motor.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
        bar.SetHealth(data.health);
        //skills.mn = data.mana;
        /*while (i <= 9)
        {
            switch (data.itemsi[i])
            {
                case "Health": inventory.items.Add(health);
                    break;
                case "Mana": inventory.items.Add(mana);
                    break;
                case "Armor": inventory.items.Add(armor);
                    break;
                case "Platelegs": inventory.items.Add(platelegs);
                    break;
                case "Helmet": inventory.items.Add(helmet);
                    break;
                case null: Debug.Log(i + " Was Empty");
                    break;
            }
        }*/
    }
}
