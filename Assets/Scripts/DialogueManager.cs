﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<Line> lines;
    private bool dialogueInProgress;

    public bool endingReached;
    public bool endingDialogueDone;

    public Text nameField;
    public Text dialogueField;
    public GameObject dialogueUI;


    private void Start()
    {
        lines = new Queue<Line>();

        dialogueInProgress = false;
        endingDialogueDone = false;
        endingReached = false;

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


    public bool DialogueInProgress()
    {
        return dialogueInProgress;
    }


    // Method to process a single dialogue (from a single character at a time)
    public void StartDialogue(Dialogue dialogue)
    {
        dialogueInProgress = true;

        dialogueField.text = "";
        nameField.text = "";
        EnableDialogueUI(true);

        foreach (Line line in dialogue.lines)
        {
            lines.Enqueue(line);
        }

        // Display the first line of dialogue
        DisplayNextSentence();
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


    private void EndDialogue()
    {
        EnableDialogueUI(false);
        lines.Clear();
        dialogueInProgress = false;

        if (endingReached)
        {
            endingDialogueDone = true;
        }
    }


    private void EnableDialogueUI(bool isEnabled)
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


