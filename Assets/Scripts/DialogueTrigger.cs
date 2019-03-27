using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private bool inDialogueTriggerRange;


    // Assumes that there will only be one dialogue per DialogueTrigger
    public Dialogue dialogue;


    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        inDialogueTriggerRange = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp("space") && inDialogueTriggerRange)
        {
            Debug.Log("About to begin Dialogue");
            dialogueManager.AddDialogue(dialogue);
            dialogueManager.StartDialogue();

        };
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Girl"))
        {
            Debug.Log("Girl in trigger range");
            inDialogueTriggerRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Girl"))
        {
            Debug.Log("Girl outside trigger range");
            inDialogueTriggerRange = false;
        }
    }
}
