using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyItem : MonoBehaviour
{
    private bool hasBeenCollected = false;

    // Called via XR Grab Interactable's Select Entered event when grabbed
    public void OnKeyGrabbed(SelectEnterEventArgs args)
    {
        if (hasBeenCollected)
            return;

        hasBeenCollected = true;

        // Register key collection in the InventoryManager
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
