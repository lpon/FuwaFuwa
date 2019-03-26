using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    DialogueManager dialogueManager;

    // Assumes that there will only be one dialogue per DialogueTrigger
    public Dialogue dialogue;


    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }


    public void AddDialogue() {
        dialogueManager.AddDialogue(dialogue);
    }


    public void StartDialogue()
    {
        dialogueManager.StartDialogue();
    }
}
