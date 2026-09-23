using UnityEngine;

public class EscapeZone : MonoBehaviour
{
    [Header("UI Feedback")]
    public GameObject escapedMessage;

    private void Start()
    {
        // Hide the escape message at startup
        if (escapedMessage != null)
            escapedMessage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Display the win message when the player enters the zone
        if (escapedMessage != null)
        {
            escapedMessage.SetActive(true);
            Debug.Log("You Escaped!");
        }
    }
}
