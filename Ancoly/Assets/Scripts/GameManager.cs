using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private InventoryManager playerInventory;

    [SerializeField]
    private List<int> requiredItemIds = new();


    public void Start()
    {
        
    }

    public void OnSceneTransition()
    {
        GameEnd(true);
    }

    private void GameEnd(bool successful)
    {
        // Do something... useful... maybe?
        SceneManager.LoadScene("EndScreen");
    }
}
