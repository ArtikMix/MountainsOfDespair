using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Invenoty/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    
    //PlayerMotor motor;
    public virtual void Use()
    {
        Debug.Log("Using " + name);
        switch (name)
        {
            case "Mana": RemoveFromInventory();
                Skills.MANA += 30;
                //Skills.ManaWasChanged = true;
                CharacterStats.skills.SetManaA(-30);
                break;
            case "Health": RemoveFromInventory();
                CharacterStats.currentHealth += 40;
                CharacterStats.bar.SetHealthA(CharacterStats.currentHealth);
                
                break;
        }
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
