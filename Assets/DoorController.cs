using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Opening Movement")]
    public Vector3 openOffset = new Vector3(0f, 2.2f, 0f);
    public float openSpeed = 2f;

    [Header("Objects To Enable After Opening")]
    public GameObject[] objectsToEnableAfterOpen;

    [Header("State")]
    public bool isOpen = false;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool hasEnabledObjects = false;

    private void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + openOffset;
    }

    private void Update()
    {
        if (isOpen)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                openPosition,
                openSpeed * Time.deltaTime
            );

            if (!hasEnabledObjects && Vector3.Distance(transform.position, openPosition) < 0.01f)
            {
                EnableObjectsAfterOpening();
            }
        }
    }

    public void OpenDoor()
    {
        if (isOpen)
            return;

        isOpen = true;
        Debug.Log("Door opening.");
    }

    private void EnableObjectsAfterOpening()
    {
        hasEnabledObjects = true;
        if (objectsToEnableAfterOpen != null)
        {
            foreach (GameObject obj in objectsToEnableAfterOpen)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                    Debug.Log("Enabled after door opened: " + obj.name);
                }
            }
        }
    }
}