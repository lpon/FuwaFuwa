using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCredits : MonoBehaviour
{
    private bool inputRecieved;
    

    private void Start()
    {
        inputRecieved = false;
    }

    private void Update()
    {
        if (Input.anyKey && !inputRecieved)
        {
            LoadCreditScene();
        }
    }

    private void LoadCreditScene()
    {
        SceneManager.LoadScene("EndCredits");
    }
}
