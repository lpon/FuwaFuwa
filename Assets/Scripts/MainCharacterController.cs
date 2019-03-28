using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    DialogueManager dialogueManager;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    float xDirection = 0f;
    float yDirection = 1f;

    public float speed;
    public bool canMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        canMove = true;
    }


    private void Update()
    {
        if (dialogueManager.endingDialogueDone)
        {
            canMove = false;
        }
        else
        {
            canMove = !dialogueManager.DialogueInProgress();
        }


        // Input is calculated in Update since it runs every frame and 
        //  therefore, will not miss registering a pressed key(as opposed to
        //  having key presses in FixedUpdate which does not run every frame)
        if (GetInput())
        {
            UpdateDirection();
            // Set Walk Layer to 1
            animator.SetLayerWeight(1, 1);
        }
        else
        {
            // Set Idle Layer to 1 using last stored directions
            animator.SetLayerWeight(0, 1);
            animator.SetLayerWeight(1, 0);
        }
    }


    private void FixedUpdate()
    {
        Move();
    }


    // Returns true iff input has been recieved
    private bool GetInput()
    {
        // If the player cannot move then ignore all input
        // This will set the player to idle in the last direction stored
        if (!canMove)
        {
            horizontal = 0f;
            vertical = 0f;

            return false;
        } 

        // GetAxisRaw() is used so character movement immediately reflects input
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        return System.Math.Abs(horizontal) > 0 ||
            System.Math.Abs(horizontal) < 0 ||
            System.Math.Abs(vertical) > 0 ||
            System.Math.Abs(vertical) < 0;
    }


    private void UpdateDirection()
    {
        xDirection = horizontal;
        yDirection = vertical;
    }


    private void AnimateMovement()
    {
        animator.SetFloat("idleUp", yDirection);
        animator.SetFloat("idleRight", xDirection);
    }


    private void Move()
    {
        // Check for diagonal movement
        if (horizontal > 0 && vertical > 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        AnimateMovement();
    }
}
