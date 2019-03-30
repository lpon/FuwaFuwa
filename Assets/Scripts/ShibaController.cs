using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaController : MonoBehaviour
{

    public int speed;
    public Rigidbody2D rb;


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    private void FixedUpdate()
    {

        rb.velocity = new Vector2(0, -speed);
    }

}
