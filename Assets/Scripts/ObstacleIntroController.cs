using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleIntroController : MonoBehaviour
{
    public GameObject katie;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Girl"))
        {
            katie.GetComponent<Animator>().SetBool("walk", true);
            collision.GetComponent<MainCharacterController>().movementOverride = true;
        }
    }
}
