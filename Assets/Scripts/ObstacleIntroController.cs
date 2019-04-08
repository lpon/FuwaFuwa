using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleIntroController : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private bool collisionOccured;

    public InstantDialogueTrigger instantDialogueTrigger;
    public GameObject katie;


    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        collisionOccured = false;
    }


    private void Update()
    {
        if (!dialogueManager.DialogueInProgress() && instantDialogueTrigger.dialogueOccured)
        {
            katie.GetComponent<Animator>().SetBool("walk", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Girl") && !collisionOccured)
        {
            collisionOccured = true;
            collision.GetComponent<MainCharacterController>().movementOverride = true;
        }
    }

}
