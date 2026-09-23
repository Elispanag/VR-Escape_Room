using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public enum DoorOpenType { Swing, Slide }

    [Header("Door Movement Type")]
    public DoorOpenType openType = DoorOpenType.Swing;

    [Header("Swing Settings (Local Rotation)")]
    [Tooltip("Rotation offset in degrees (try Y or Z axis)")]
    public Vector3 openRotationOffset = new Vector3(0, 0, 90f);

    [Header("Slide Settings (Position)")]
    public Vector3 openOffset = new Vector3(0, 2.5f, 0);

    [Header("Speed")]
    public float openSpeed = 2f;

    [Header("Objects To Enable After Opening")]
    public List<GameObject> objectsToEnableAfterOpening = new List<GameObject>();

    private bool isOpening = false;
    private bool isOpened = false;

    private Vector3 initialPosition;
    private Vector3 targetPosition;

    private Quaternion initialLocalRotation;
    private Quaternion targetLocalRotation;

    private void Start()
    {
        // Store starting transforms and calculate target open transforms
        initialPosition = transform.localPosition;
        targetPosition = initialPosition + openOffset;

        initialLocalRotation = transform.localRotation;
        targetLocalRotation = initialLocalRotation * Quaternion.Euler(openRotationOffset);
    }

    public void OpenDoor()
    {
        if (!isOpened && !isOpening)
        {
            StartCoroutine(OpenDoorRoutine());
        }
    }

    private IEnumerator OpenDoorRoutine()
    {
        isOpening = true;

        // Animate door rotation for swing type
        if (openType == DoorOpenType.Swing)
        {
            while (Quaternion.Angle(transform.localRotation, targetLocalRotation) > 0.5f)
            {
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetLocalRotation, openSpeed * 50f * Time.deltaTime);
                yield return null;
            }
            transform.localRotation = targetLocalRotation;
        }
        // Animate door position for slide type
        else if (openType == DoorOpenType.Slide)
        {
            while (Vector3.Distance(transform.localPosition, targetPosition) > 0.01f)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, openSpeed * Time.deltaTime);
                yield return null;
            }
            transform.localPosition = targetPosition;
        }

        isOpening = false;
        isOpened = true;

        // Enable trigger zones or UI after the door fully opens
        foreach (var obj in objectsToEnableAfterOpening)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }
}