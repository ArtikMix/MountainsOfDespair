using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeThrow : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject grenadePrefab;
    public Image grenadeSkillImg;
    Skills skills;
    void Start()
    {
        skills = GetComponent<Skills>();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)&&Skills.MANA>=50)
        {
            grenadeSkillImg.gameObject.SetActive(false);
            skills.SetMana(50);
            if (Input.GetMouseButtonDown(0))
            {
                ThrowGrenade();
                StartCoroutine(grenadeImgActive());
            }
            
        }
    }
    IEnumerator grenadeImgActive()
    {
        yield return new WaitForSeconds(20f);
        grenadeSkillImg.gameObject.SetActive(true);
    }
    public void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
