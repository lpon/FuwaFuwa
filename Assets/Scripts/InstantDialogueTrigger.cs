using System.Collections.Generic;
using UnityEngine;

public class InstantDialogueTrigger : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private bool dialogueOccured;

    public Dialogue dialogue;


    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueOccured = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Girl"))
        {
            if (!dialogueOccured)
            {
                dialogueOccured = true;
                dialogueManager.StartDialogue(dialogue);
            }
        }
    }
}
