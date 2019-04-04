using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCreditController : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level1");
    }
}
