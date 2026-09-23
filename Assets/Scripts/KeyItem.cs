using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyItem : MonoBehaviour
{
    private bool hasBeenCollected = false;

    public void OnKeyGrabbed(SelectEnterEventArgs args)
    {
        if (hasBeenCollected)
            return;

        hasBeenCollected = true;
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.AddRoom1Key();
        }
        else
        {
            Debug.LogWarning("KeyItem: No InventoryManager found in scene.");
        }
    }
}
