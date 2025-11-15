using System;
using UnityEngine;

public class Keyhole : MonoBehaviour
{
    public GameObject KeyholeUI;
    public GameObject sightIndicator;
    public KeyCode InteractKey = KeyCode.E;

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
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(InteractKey))
        {
            bool isActive = KeyholeUI.activeSelf;
            KeyholeUI.SetActive(!isActive);
        }
    }
}
