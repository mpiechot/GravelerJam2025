using UnityEngine;

public class IntroOverlay : MonoBehaviour
{
    [SerializeField] private KeyCode closeKey = KeyCode.E;
    [SerializeField] private float autoCloseAfterSeconds = 10f;
    [SerializeField] private PlayerController player; // optional: Player sperren

    private float timer = 0f;
    private bool isActive = false;

    private void Start()
    {
        // Overlay aktiv halten
        gameObject.SetActive(true);
        isActive = true;

        if (player != null)
            player.enabled = false;
    }

    private void Update()
    {

        timer += Time.deltaTime;

        // schließen bei Taste oder Zeitablauf
        if (Input.GetKeyDown(closeKey) || timer >= autoCloseAfterSeconds)
        {
            CloseOverlay();
        }
    }

    private void CloseOverlay()
    {
        isActive = false;

        // Player wieder freigeben
        if (player != null)
            player.enabled = true;

        // Canvas ausblenden
        gameObject.SetActive(false);
    }
}