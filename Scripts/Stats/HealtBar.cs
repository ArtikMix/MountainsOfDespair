using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public GameObject healingAnim;
    public int hp;
    void Awake()
    {
        slider.maxValue = 100;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
        slider.value = health;
        hp = health;
    }

    public void SetHealthA(int health)
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
        slider.value = health;
        healingAnim.transform.position = transform.position;
        healingAnim.transform.rotation = transform.rotation;
        StartCoroutine(HealAnimDestroy());
        hp = health;
    }
    IEnumerator HealAnimDestroy()
    {
        yield return new WaitForSeconds(2f);
        healingAnim.transform.position = new Vector3(-3500, 22, 670);

    }

}
