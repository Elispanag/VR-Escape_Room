using UnityEngine;

public class DoorKeyLock : MonoBehaviour
{
    [Header("Door")]
    public DoorController door;

    [Header("Key Detection")]
    public string requiredKeyTag = "Key";
    public bool requireInventoryKey = true;

    private bool unlocked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (unlocked)
            return;

        Rigidbody keyRigidbody = other.attachedRigidbody;
        if (keyRigidbody == null)
            return;

        if (!keyRigidbody.CompareTag(requiredKeyTag))
            return;

        if (requireInventoryKey)
        {
            if (InventoryManager.Instance == null)
            {
                Debug.LogWarning("DoorKeyLock: InventoryManager not found.");
                return;
            }

            if (!InventoryManager.Instance.HasRoom1Key())
            {
                Debug.Log("Correct key is near the lock, but it has not been collected yet.");
                return;
            }
        }

        UnlockDoor();
    }

    private void UnlockDoor()
    {
        unlocked = true;
        if (door != null)
        {
            door.OpenDoor();
            Debug.Log("Door unlocked with key.");
        }
        else
        {
            Debug.LogError("DoorKeyLock: DoorController is not assigned.");
        }
    }
}