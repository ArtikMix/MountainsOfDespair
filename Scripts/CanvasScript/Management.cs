using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Management : MonoBehaviour
{
    private int place = 0;
    public Text des;
    DataBase data;
    public Button ExitButton;
    public Canvas allCanvas, kvestCanvas;
  
    void Start()
    {
        data = GetComponent<DataBase>();
        des.text = data.Description[place];
    }

    void Update()
    {
        if (place == 9)
        {
            allCanvas.gameObject.SetActive(true);
            kvestCanvas.gameObject.SetActive(false);
        }
    }
    public void NextClick()
    {
        place++;
        des.text = data.Description[place];
    }


}
