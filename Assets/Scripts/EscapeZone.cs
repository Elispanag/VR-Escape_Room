using UnityEngine;
public class EscapeZone : MonoBehaviour
{
	public GameObject escapedMessage;
private void Start()
{
    if (escapedMessage != null)
        escapedMessage.SetActive(false);
}

private void OnTriggerEnter(Collider other)
{
    if (escapedMessage != null)
    {
        escapedMessage.SetActive(true);
        Debug.Log("You Escaped!");
    }
}
}
