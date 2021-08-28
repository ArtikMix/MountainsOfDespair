using UnityEngine;
using UnityEngine.UI;

public class InventarySlot : MonoBehaviour
{
    public Image icon;
    Item item;
    public Button removeButton;
    public GameObject pl;
    public GameObject hA;
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void onRemoveButton()
    {
        Inventory.instance.Remove(item);
    }
    
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();

        }
    }
}
