using System.Collections.Generic;
using UnityEngine;

public class StartDialogueTrigger : MonoBehaviour
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
        Debug.Log("Collision detected");

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
