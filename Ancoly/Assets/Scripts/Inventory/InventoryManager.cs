using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    private List<InventoryObject> inventory = new();

    public IReadOnlyList<InventoryObject> Items => inventory;

    public void AddToInventory(InventoryObject objectToAdd)
    {
        inventory.Add(objectToAdd);
    }

    public void RemoveFromInventory(InventoryObject objectToRemove)
    {
        inventory.Remove(objectToRemove);
    }

    public bool IsInsideInventory(string itemName)
    {
        return inventory.Any(item => item.Name.Equals(itemName));
    }
}
