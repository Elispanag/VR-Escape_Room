using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    [Header("Puzzle Settings")]
    public string buttonId;
    public ButtonSequencePuzzle puzzle;
    [Header("Audio")]
    public AudioSource pressAudio;

    private bool alreadyPressed = false;

    private void OnTriggerEnter(Collider other)
    {
        // Prevent registering multiple triggers from a single press
        if (alreadyPressed)
            return;

        alreadyPressed = true;

        //Play button press sound
        if (pressAudio != null)
        {
            pressAudio.Play();
        }

        // Send this button's ID to the sequence puzzle manager
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
        // Reset state when hand or interactor leaves the trigger area
        alreadyPressed = false;
    }
}