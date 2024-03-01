using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    //Singleton Pattern
    public static Inventory Instance; //you have to have one inventory at all times
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }  
        Instance = this;
    }
    //
    #endregion

    //Delegate = event that you can subscribe diff methods to. When triggered all subscribed methods are called (Basically same func as EventBus
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add (Item item)
    {
        if (item.isDefault) return false;
        if (items.Count >= space) 
        {
            Debug.Log("Not enough room in inventory.");
            return false;
        }
        items.Add(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        
        return true;
    }
    public void Remove (Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
