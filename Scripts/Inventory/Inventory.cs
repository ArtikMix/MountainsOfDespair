using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    public string[] itemes;
    private bool wasAdded = false;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More yhan one instance of Inventory found!");
            return;
        }
        instance = this;
        itemes = new string[9];
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 9;
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }
            items.Add(item);
            wasAdded = false;
            for (int i = 0; i<9; i++)
            {
                if (itemes[i] == null && wasAdded == false)
                {
                    itemes[i] = item.name;
                    wasAdded = true;
                }
            }
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}