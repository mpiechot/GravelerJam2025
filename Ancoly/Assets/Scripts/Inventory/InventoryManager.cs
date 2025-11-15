using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class InventoryManager : MonoBehaviour
{
    private List<InventoryObject> inventory = new();

    public IReadOnlyList<InventoryObject> Items => inventory;

    public event EventHandler InventoryChanged;

    public void AddToInventory(InventoryObject objectToAdd)
    {
        inventory.Add(objectToAdd);
        InventoryChanged.Invoke(this, EventArgs.Empty);
    }

    public void RemoveFromInventory(InventoryObject objectToRemove)
    {
        inventory.Remove(objectToRemove);
        InventoryChanged.Invoke(this, EventArgs.Empty);
    }

    public bool IsInsideInventory(string itemName)
    {
        return inventory.Any(item => item.Name.Equals(itemName));
    }
}
