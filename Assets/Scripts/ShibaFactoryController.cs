using UnityEngine;

public class ShibaFactoryController : MonoBehaviour
{
    private bool started;
    public ShibaFactory shibaFactory;

    private void Start()
    {
        started = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Girl") && gameObject.CompareTag("startFactory") && !started)
        {
            started = true;
            shibaFactory.StartShibaFactory();
        }
        else if ((collision.CompareTag("Girl") && gameObject.CompareTag("endFactory")))
        {
            shibaFactory.StopShibaFactory();
        }
    }
}
