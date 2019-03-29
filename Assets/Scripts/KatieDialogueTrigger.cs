using UnityEngine;

public class KatieDialogueTrigger : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private bool dialogueOccured;
    private MainCharacterController mainCharacter;

    public Dialogue dialogue;


    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        mainCharacter = FindObjectOfType<MainCharacterController>();
        dialogueOccured = false;
    }

    private void Update()
    {
        if (dialogueOccured && !dialogueManager.DialogueInProgress())
        {
            mainCharacter.movementOverride = false;
        }
    }

    public void TriggerDialogue()
    {
        if (!dialogueOccured && !dialogueManager.DialogueInProgress())
        {
            dialogueOccured = true;
            dialogueManager.StartDialogue(dialogue);
        } 
    }
}

