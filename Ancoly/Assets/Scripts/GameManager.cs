using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private InventoryManager playerInventory;

    [SerializeField]
    private List<int> requiredItemIds = new();


    public void Start()
    {
        playerInventory.InventoryChanged += OnInventoryChanged;
    }

    private void OnInventoryChanged(object sender, EventArgs args)
    {
        if(requiredItemIds.All(id => playerInventory.Items.Any(item => item.Id == id)))
        {
            GameEnd(true);
        }
    }

    private void GameEnd(bool successful)
    {
        // Do something... useful... maybe?
    }
}
