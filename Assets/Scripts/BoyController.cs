using UnityEngine;

public class BoyController : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Girl"))
        {
            collision.GetComponent<MainCharacterController>().canMove = false;

            // Add dialogue for this character
            dialogueTrigger.AddDialogue();
            // Add dialogue for the character this character collided with
            collision.GetComponent<DialogueTrigger>().AddDialogue();

            dialogueTrigger.StartDialogue();
        }
    }
}
