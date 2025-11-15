using System;
using UnityEngine;

public class Keyhole : MonoBehaviour, IInteractable
{
    public GameObject KeyholeUI;
    public GameObject sightIndicator;  

    private bool isPlayerInRange = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            sightIndicator.SetActive(true);

        }
    }
    
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            sightIndicator.SetActive(false);
            KeyholeUI.SetActive(false);
        }
    }

    public void Interact(InventoryManager inventory)
    {
        bool isActive = KeyholeUI.activeSelf;
        KeyholeUI.SetActive(!isActive);
    }
}
