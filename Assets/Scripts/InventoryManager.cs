using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Singleton instance accessible from other scripts
    public static InventoryManager Instance { get; private set; }

    [Header("Inventory Status")]
    public bool hasRoom1Key = false;

    private void Awake()
    {
        // Enforce a single instance of InventoryManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Called when the player picks up the correct key
    public void AddRoom1Key()
    {
        hasRoom1Key = true;
        Debug.Log("Inventory: Room 1 key collected.");
    }

    // Checks if the Room 1 key is currently collected
    public bool HasRoom1Key()
    {
        return hasRoom1Key;
    }
}