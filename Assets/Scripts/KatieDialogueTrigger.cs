using UnityEngine;

public class KatieDialogueTrigger : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private bool dialogueOccured;
    private bool releasedCharacter;
    private MainCharacterController mainCharacter;

    public ShibaFactoryController shibaFactoryController;
    public Dialogue dialogue;


    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        mainCharacter = FindObjectOfType<MainCharacterController>();
        dialogueOccured = false;
        releasedCharacter = false;
    }

    private void Update()
    {
        if (dialogueOccured && !dialogueManager.DialogueInProgress() && !releasedCharacter)
        {
            mainCharacter.movementOverride = false;
            releasedCharacter = true;
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

