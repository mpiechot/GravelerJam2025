using UnityEngine;
using System.Collections.Generic;

public class InventoryObject : MonoBehaviour, IInteractable
{
    [field: SerializeField]
    private List<string> ItemSet = new();

    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField]
    public int Id { get; private set; }

    public bool IsPartOfSet(string setName)
    {
        return ItemSet.Contains(setName);
    }

    public void Interact(InventoryManager inventory)
    {
        gameObject.SetActive(false);
    }

    public IReadOnlyList<string> ItemSets => ItemSet;
}
