using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    float xDirection = 0f;
    float yDirection = 1f;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        // Input is calculated in Update since it runs every frame and 
        //  therefore, will not miss registering a pressed key(as opposed to
        //  having key presses in FixedUpdate which does not run every frame)
        CheckInput();
        UpdateDirection();

    }


    void FixedUpdate()
    {
        // Set parameters for sprite animation movement
        AnimateMovement();
        Move();
    }


    void Move()
    {
        // Check for diagonal movement
        if (horizontal > 0 && vertical > 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }


    void CheckInput()
    {
        // GetAxisRaw() is used so character movement immediately reflects input
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }


    void UpdateDirection()
    {
        // Only update direction when input is pressed
        // If no input is recieved do not update directions
        if (System.Math.Abs(horizontal) > 0 ||
            System.Math.Abs(horizontal) < 0||
            System.Math.Abs(vertical) > 0 ||
            System.Math.Abs(vertical) < 0)
        {
            xDirection = horizontal;
            yDirection = vertical;
        }
    }


    void AnimateMovement()
    {
        animator.SetFloat("idleUp", yDirection);
        animator.SetFloat("idleRight", xDirection);
    }
}
