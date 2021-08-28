using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource natSound;
    public Transform player;
    private int plusOrMinus;

    private void Start()
    {
        natSound.volume = 0f;
    }
    void Update()
    {
        switch (transform.name)
        {
            case "Audio Source":
                if (Vector3.Distance(player.transform.position, natSound.transform.position) < 60f && natSound.volume <= 1f)
                {
                    natSound.volume += 0.00005f;
                    plusOrMinus = 2;
                }
                else if (Vector3.Distance(player.transform.position, natSound.transform.position)>60f && natSound.volume >= 0f)
                {
                    natSound.volume -= 0.00005f;
                    plusOrMinus = 1;
                }
                break;
        } 
    }

    IEnumerator NatureSound()
    {
        while(Vector3.Distance(player.transform.position, natSound.transform.position)<60f && natSound.volume <= 1f || Vector3.Distance(player.transform.position, natSound.transform.position)>60f && natSound.volume>=0f)
        {
            yield return new WaitForSeconds(0.5f);
            natSound.volume += Mathf.Pow(-1, plusOrMinus) * 0.05f;
        }
        
    }
}
