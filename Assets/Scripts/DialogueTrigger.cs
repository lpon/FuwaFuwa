using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private int nextDialogue = 0;

    // Assumes that there will only be one dialogue per DialogueTrigger
    public Dialogue[] dialogues;



    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }


    public void AddDialogue() {
        if (dialogues.Length > 0 && nextDialogue < dialogues.Length)
        {
            dialogueManager.AddDialogue(dialogues[nextDialogue]);
            nextDialogue++;
        } 
    }


    public void StartDialogue()
    {
        dialogueManager.StartDialogue();
    }
}
