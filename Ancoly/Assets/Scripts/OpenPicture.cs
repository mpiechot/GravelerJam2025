using UnityEngine;

public class OpenPicture : MonoBehaviour
{
    public GameObject KeyholeUI;
    public GameObject swirl;
    private bool inRange = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            bool isActive = KeyholeUI.activeSelf;

            KeyholeUI.SetActive(!isActive);
            Time.timeScale = isActive ? 1f : 0f;
            swirl.SetActive(!isActive);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;

        }
    }
}
