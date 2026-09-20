using System.Collections.Generic;
using UnityEngine;

public class ButtonSequencePuzzle : MonoBehaviour
{
    [Header("Sequence")]
    public List<string> correctSequence = new List<string> { "Blue", "Green", "Red" };

    [Header("Final Door")]
    public DoorController finalDoor;

    private List<string> currentSequence = new List<string>();
    private bool solved = false;

    public void PressButton(string buttonId)
    {
        if (solved)
            return;

        currentSequence.Add(buttonId);
        int index = currentSequence.Count - 1;

        if (currentSequence[index] != correctSequence[index])
        {
            Debug.Log("Wrong sequence. Resetting puzzle.");
            currentSequence.Clear();
            return;
        }

        Debug.Log("Correct button: " + buttonId);

        if (currentSequence.Count == correctSequence.Count)
        {
            solved = true;
            Debug.Log("Correct sequence. Final door unlocked.");
            if (finalDoor != null)
            {
                finalDoor.OpenDoor();
            }
            else
            {
                Debug.LogError("ButtonSequencePuzzle: Final door is not assigned.");
            }
        }
    }
}