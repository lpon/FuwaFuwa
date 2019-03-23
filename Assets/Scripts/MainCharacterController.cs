using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    int horizontal;
    int vertical;
    float moveLimiter = 0.7f;

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

        // GetAxisRaw() is used so character movement immediately reflects input
        horizontal = (int) Input.GetAxisRaw("Horizontal");
        vertical = (int) Input.GetAxisRaw("Vertical");

    }


    void FixedUpdate()
    {
        Debug.Log(horizontal);
        Debug.Log(vertical);

        // Set parameters for sprite animation movement
        animateMainCharacter();
        moveMainCharacter();
    }


    void moveMainCharacter()
    {
        // Check for diagonal movement
        if (horizontal > 0 && vertical > 0)
        {
            rb.velocity = new Vector2(
                                        (float) horizontal * moveLimiter * speed,
                                        (float) vertical * moveLimiter * speed
                                    );
        }
        else
        {
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }

    }


    void animateMainCharacter()
    {
        animator.SetBool("walkUp", false);
        animator.SetBool("walkDown", false);
        animator.SetBool("walkLeft", false);
        animator.SetBool("walkRight", false);

        if (vertical > 0)
        {
            animator.SetBool("walkUp", true);
        }
        if (vertical < 0)
        {
            animator.SetBool("walkDown", true);
        }
        if (horizontal > 0)
        {
            animator.SetBool("walkRight", true);
        }
        if (horizontal < 0)
        {
            animator.SetBool("walkLeft", true);
        }
    }
}
