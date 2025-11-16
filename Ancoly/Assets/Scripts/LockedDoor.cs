using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LockedDoor : MonoBehaviour, IInteractable
{
    [field: SerializeField]
    public int KeyId { get; private set; }

    [SerializeField]
    private SoundEffectPlayer soundEffectPlayer;

    public bool DoorOpen { get; private set; } = false;
    public GameObject KeyholeUI;
    public bool hasKeyhole = true;
    public bool pincode = false;
    [SerializeField] private GameObject keyLock;
    public UnityEvent sceneTransition;

    public void Interact(InventoryManager inventory)
    {
        if (pincode)
        {
            keyLock.SetActive(true);
        }
        else
        {
            if (!DoorOpen && inventory.Items.Any(item => item.Id == KeyId))
            {
                soundEffectPlayer.PlaySound(SoundType.DOOR_OPEN);
                OpenDoor();
                DoorOpen = true;
            }
            else
            {
                soundEffectPlayer.PlaySound(SoundType.DOOR_LOCKED);
                if (hasKeyhole)
                {
                    bool isActive = KeyholeUI.activeSelf;
                    KeyholeUI.SetActive(!isActive);
                    Time.timeScale = isActive ? 1f : 0f;
                }

            }
        }
    }
    public void OpenDoor()
    {
        gameObject.SetActive(false);
        sceneTransition.Invoke();
    }
}
