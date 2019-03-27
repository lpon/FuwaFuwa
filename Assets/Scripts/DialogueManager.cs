using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string[]> sentences;

    public Text nameField;
    public Text dialogueField;
    public GameObject dialogueUI;


    void Start()
    {
        this.sentences = new Queue<string[]>();
        EnableDialogueUI(false);
    }


    // Add multiple dialogues that will be processed one-at-a-time
    public void AddDialogue(Dialogue dialogue)
    {
        foreach (string sentence in dialogue.sentences)
        {
            string[] line = new string[2];
            line[0] = dialogue.name;
            line[1] = sentence;

            sentences.Enqueue(line);
        }
    }


    // Method to process a single dialogue (from a single character at a time)
    public void StartDialogue()
    {
        dialogueField.text = "";
        nameField.text = "";
        EnableDialogueUI(true);

        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string[] line = sentences.Dequeue();

        nameField.text = line[0];
        string sentence = line[1];

        // Make sure that everytime DisplayNextSentence is called, TypeSentence starts from scratch
        // This is to prevent a player clicking continue before a full sentence has been typed out
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }


    void EndDialogue()
    {
        EnableDialogueUI(false);
        sentences.Clear();
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


