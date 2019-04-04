using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private DialogueManager dialogueManager;
 
    public GameObject canvas;
    public bool endReached;


    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(true);
        endReached = false;
        dialogueManager = FindObjectOfType<DialogueManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (dialogueManager.endingDialogueDone)
        {
            Invoke("LoadEndingScene", 1f);
        }
    }


    private void LoadEndingScene()
    {
        SceneManager.LoadScene("EndingScene");
    }
}
