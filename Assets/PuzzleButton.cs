using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    public string buttonId;
    public ButtonSequencePuzzle puzzle;

    private bool alreadyPressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (alreadyPressed)
            return;

        alreadyPressed = true;
        if (puzzle != null)
        {
            puzzle.PressButton(buttonId);
            Debug.Log("Pressed button: " + buttonId);
        }
        else
        {
            Debug.LogError("PuzzleButton: Puzzle reference is missing.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        alreadyPressed = false;
    }
}
