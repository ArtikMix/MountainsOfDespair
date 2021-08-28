using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public static int currentHealth;//{ get; private set; }
    public static HealtBar bar;
    public Stat damage;
    public Stat armor;
    public Text money;
    public int dublons = 0;
    public GameObject deathAnim;
    public static Skills skills;
    void Awake()
    {
        currentHealth = maxHealth;
        bar = GetComponent<HealtBar>();
        skills = GetComponent<Skills>();
    }

    void Update()
    {
        money.text = "Дублоны " + dublons.ToString();
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        if (damage>0 && transform.name == "Player")
        bar.SetHealth(currentHealth);
        Debug.Log(transform.name +" takes "+ damage);
        
        if (currentHealth <= 0)
        {
            Die();
            Instantiate(deathAnim, transform.position, transform.rotation);
            dublons += 3;
        }
    }
    public virtual void Die()
    {
        Debug.Log(transform.name + " died :-(");
    }
}
