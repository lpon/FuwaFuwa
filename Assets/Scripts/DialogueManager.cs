using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<Line> lines;
    private bool dialogueInProgress;

    public Text nameField;
    public Text dialogueField;
    public GameObject dialogueUI;


    private void Start()
    {
        lines = new Queue<Line>();
        dialogueInProgress = false;
        EnableDialogueUI(false);

    }


    private void Update()
    {
        if (dialogueInProgress)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                DisplayNextSentence();
            }
        }

    }


    // Add multiple dialogues that will be processed one-at-a-time
    public void AddDialogue(Dialogue dialogue)
    {
        foreach (Line line in dialogue.lines)
        {
            lines.Enqueue(line);
        }
    }


    // Method to process a single dialogue (from a single character at a time)
    public void StartDialogue()
    {
        dialogueField.text = "";
        nameField.text = "";
        EnableDialogueUI(true);

        // Display the first line of dialogue
        DisplayNextSentence();

        dialogueInProgress = true;
    }


    public void DisplayNextSentence()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        Line line = lines.Dequeue();

        nameField.text = line.characterName;
        string sentence = line.text;

        // Make sure that everytime DisplayNextSentence is called, TypeSentence starts from scratch
        // This is to prevent a player clicking continue before a full sentence has been typed out
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }


    void EndDialogue()
    {
        EnableDialogueUI(false);
        lines.Clear();
        dialogueInProgress = true;
    }


    void EnableDialogueUI(bool isEnabled)
    {
        nameField.enabled = isEnabled;
        dialogueField.enabled = isEnabled;
        dialogueUI.SetActive(isEnabled);
    }


    IEnumerator TypeSentence(string sentence)
    {
        dialogueField.text = "";
        foreach (char c in sentence.ToCharArray())
        {
            dialogueField.text += c;
            // Wait a single frame after each letter is appended to the field
            yield return StartCoroutine(WaitFor.Frames(2));
        }
    }
}


public static class WaitFor
{
    public static IEnumerator Frames(int frameCount)
    {
        while (frameCount > 0)
        {
            frameCount--;
            yield return null;
        }
    }
}


