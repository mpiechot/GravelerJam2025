using System;
using UnityEngine;

public class Keyhole : MonoBehaviour, IInteractable
{
    public GameObject KeyholeUI;
    public GameObject sightIndicator;  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sightIndicator.SetActive(true);

        }
    }
    
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sightIndicator.SetActive(false);
            KeyholeUI.SetActive(false);
            print("Exited Keyhole Trigger"+ KeyholeUI);
        }
    }

    public void Interact(InventoryManager inventory)
    {
        bool isActive = KeyholeUI.activeSelf;
        KeyholeUI.SetActive(!isActive);
    }
}
