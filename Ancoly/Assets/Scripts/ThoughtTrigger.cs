using UnityEngine;

public class ThoughtTrigger : MonoBehaviour
{
    public ThoughtDialogue dialogue;
    public bool triggerOnce = true;

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (triggerOnce && hasTriggered) return;

        if (ThoughtManager.Instance != null)
        {
            ThoughtManager.Instance.StartDialogue(dialogue);
            hasTriggered = true;
        }
    }
}
