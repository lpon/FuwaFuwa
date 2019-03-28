using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private bool inDialogueTriggerRange;
    private bool dialogueOccured;

    public Dialogue dialogue;


    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        inDialogueTriggerRange = false;
        dialogueOccured = false;
    }


    private void Update()
    {
        if (!dialogueOccured)
        {
            if (inDialogueTriggerRange && Input.GetKeyUp(KeyCode.Return))
            {
                dialogueOccured = true;
                dialogueManager.StartDialogue(dialogue);
            }
        }
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
