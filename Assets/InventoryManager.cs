using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    public bool hasRoom1Key = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddRoom1Key()
    {
        hasRoom1Key = true;
        Debug.Log("Inventory: Room 1 key collected.");
    }

    public bool HasRoom1Key()
    {
        return hasRoom1Key;
    }
}