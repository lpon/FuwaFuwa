using UnityEngine;
using UnityEngine.SceneManagement;

public class ShibaController : MonoBehaviour
{

    public int speed;
    public Rigidbody2D rb;

    private Animator animator;


    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, -speed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Girl"))
        {
            collision.GetComponent<MainCharacterController>().movementOverride = true;
            animator.SetBool("walk", false);
            speed = 0;
            Invoke("LoadGameOverScene", 1f);
        }
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

}
