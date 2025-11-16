using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    public float InteractionRadius { get; private set; }

    [field: SerializeField]
    public InventoryManager inventory { get; private set; }

    [field: SerializeField]
    public KeyCode InteractKey { get; private set; } = KeyCode.E;

    [SerializeField]
    private SoundEffectPlayer soundEffectPlayer;

    [SerializeField]
    private float sighTimer = 10f;

    [SerializeField]
    private LayerMask interactionMask;

    private float currentSighTime;

    void Start()
    {
        currentSighTime = sighTimer;
    }

    void Update()
    {
        if (Input.GetKeyDown(InteractKey))
        {
            HandleInteraction();
        }

        HandleSighTimer();
        if (inventory.IsInsideInventory("Taschenlampe"))
        {
            GetComponent<PlayerMovement>().ActivateLighter();
        }
    }

    private void HandleInteraction()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, InteractionRadius, interactionMask);

        Debug.Log("Test: " + hits.Length);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<IInteractable>(out var interactable))
            {
                interactable.Interact(inventory);

                if (hit.TryGetComponent<InventoryObject>(out var inventoryObject))
                {
                    inventory.AddToInventory(inventoryObject);
                    soundEffectPlayer.PlaySound(SoundType.ITEM_PICKUP);
                }
            }
        }
    }

    private void HandleSighTimer()
    {
        currentSighTime -= Time.deltaTime;
        if (currentSighTime <= 0f)
        {
            if (soundEffectPlayer != null)
            {
                soundEffectPlayer.PlaySound(SoundType.SIGH);
            }

            currentSighTime = sighTimer;
        }
    }

    // Gizmo zeichnen (nur zur Orientierung im Editor)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, InteractionRadius);

    }
}
