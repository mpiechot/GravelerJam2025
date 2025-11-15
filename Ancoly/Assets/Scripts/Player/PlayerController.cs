using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    public float InteractionRadius { get; private set; }

    [field: SerializeField]
    public InventoryManager inventory { get; private set; }

    [field: SerializeField]
    public KeyCode InteractKey { get; private set; } = KeyCode.E;

    void Update()
    {
        if (Input.GetKeyDown(InteractKey))
        {
            HandleInteraction();
        }
    }

    private void HandleInteraction()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, InteractionRadius);

        Debug.Log("Test: " + hits.Length);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<IInteractable>(out var interactable))
            {
                interactable.Interact(inventory);

                if (hit.TryGetComponent<InventoryObject>(out var inventoryObject))
                {
                    inventory.AddToInventory(inventoryObject);
                }
            }
        }
    }
}
