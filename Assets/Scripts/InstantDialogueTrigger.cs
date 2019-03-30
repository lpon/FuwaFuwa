using UnityEngine;

public class InstantDialogueTrigger : MonoBehaviour
{
    private DialogueManager dialogueManager;

    public bool dialogueOccured;
    public Dialogue dialogue;


    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueOccured = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Katie"))
        {
            return;
        } else if (collision.CompareTag("Girl"))
        {
            if (!dialogueOccured)
            {
                dialogueOccured = true;
                dialogueManager.StartDialogue(dialogue);
            }
        }
    }
}
