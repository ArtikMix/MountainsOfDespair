using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{
    public NavMeshAgent agent;
    public Image speedImage;
    private float speed = 5f;
    private int n;
    private bool sI = true;
    public static int MANA = 100;
    public Slider slider;
    public Image fill;
    //public static bool ManaWasChanged = false;
    public float throwForce = 40f;
    public GameObject grenadePrefab;
    public Image grenadeSkillImg;
    public GameObject playerLight; //отсюда гранаты вылетают просто)
    public GameObject manaAnim;
    //public int mn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && MANA >= 50)
        {
            grenadeSkillImg.gameObject.SetActive(false);
            SetMana(50);
            //if (Input.GetMouseButtonDown(0)) почему-то с этим условием не работает
           // {
                ThrowGrenade();
                StartCoroutine(grenadeImgActive());
            //}
        }
        if (Input.GetKeyDown(KeyCode.Q) && sI == true && MANA >= 15)
        {
            SpeedSkillPlus();
            SetMana(15);
        }
        /*if (ManaWasChanged == true)
        {
            SetManaA(0);
        }*/
    }
    #region GrenadeSkill
    IEnumerator grenadeImgActive()
    {
        yield return new WaitForSeconds(20f);
        grenadeSkillImg.gameObject.SetActive(true);
    }
    public void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, playerLight.transform.position, playerLight.transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
    #endregion
    void Awake()
    {
        slider.maxValue = 100;
    }
    void Start()
    {
        //MANA = mn;
        MANA = 100;
        agent = GetComponent<NavMeshAgent>();
        slider.value = MANA;
        //ManaWasChanged = false;
    }
    #region speedSkil
    void SpeedSkillPlus()
    {
        StartCoroutine(spSkill());
        agent.speed =Mathf.Pow(3, n) * speed;
        speedImage.gameObject.SetActive(false);
        sI = false;
    }

    void SpeedSkillMinus()
    {
        agent.speed = Mathf.Pow(3, n) * speed;
        StartCoroutine(speedOtkat());
    }

    IEnumerator spSkill()
    {
        n = 1;
        yield return new WaitForSeconds(3f);
        n = 0;
        SpeedSkillMinus();
    }

    IEnumerator speedOtkat()
    {
        yield return new WaitForSeconds(1f);
        sI = true;
        speedImage.gameObject.SetActive(true);
    }
    #endregion
    public void SetMana(int mana)
    {
        MANA -= mana;
        slider.value = MANA;
        //mn = MANA;
        //ManaWasChanged = false;
    }
    public void SetManaA(int mana)
    {
        //mn = MANA;
        slider.value = MANA;
        //ManaWasChanged = false;
        manaAnim.transform.position = transform.position;
        manaAnim.transform.rotation = transform.rotation;
        StartCoroutine(manaAnimD());
    }
    IEnumerator manaAnimD()
    {
        yield return new WaitForSeconds(2f);
        manaAnim.transform.position = new Vector3(-3600, 16, 646);
    }
}
