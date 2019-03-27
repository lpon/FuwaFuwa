using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private bool inDialogueTriggerRange;
    private bool dialogueOccured = false;


    // Assumes that there will only be one dialogue per DialogueTrigger
    public Dialogue dialogue;


    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        inDialogueTriggerRange = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp("space") && inDialogueTriggerRange && !dialogueOccured)
        {
            dialogueOccured = true;

            dialogueManager.AddDialogue(dialogue);
            dialogueManager.StartDialogue();

        };
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Girl"))
        {
            inDialogueTriggerRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Girl"))
        {
            inDialogueTriggerRange = false;
        }
    }
}
