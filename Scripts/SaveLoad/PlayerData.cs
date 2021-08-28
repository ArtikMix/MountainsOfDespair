using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public int mana;
    public float[] position;
    public float[] rotation;
    public string[] itemsi;

    public PlayerData (HealtBar HB, Skills SK, PlayerMotor PM, Inventory I)
    {
        itemsi = new string[9];
        position = new float[3];
        rotation = new float[3];
        health = HB.hp;
        //mana = SK.mn;
        position[0] = PM.pos[0];
        position[1] = PM.pos[1];
        position[2] = PM.pos[2];
        rotation[0] = PM.rot[0];
        rotation[1] = PM.rot[1];
        rotation[2] = PM.rot[2];
        /*for (int i = 0; i<9; i++)
        {
            itemsi[i] = I.itemes[i];
        }*/
    }
}
