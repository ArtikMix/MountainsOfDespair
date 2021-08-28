using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animka : MonoBehaviour
{
    public GameObject healAnim;
    public void HealAnim()
    {
        Instantiate(healAnim, transform.position, transform.rotation);
    }
}
