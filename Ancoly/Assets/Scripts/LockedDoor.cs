using UnityEngine;
using System.Linq;

public class LockedDoor : MonoBehaviour, IInteractable
{
    [field: SerializeField]
    public int KeyId { get; private set; }

    public bool DoorOpen { get; private set; } = false;

    public void Interact(InventoryManager inventory)
    {
        if(!DoorOpen && inventory.Items.Any(item => item.Id == KeyId))
        {
            DoorOpen = true;
        }
    }
}
