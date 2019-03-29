using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private DialogueManager dialogueManager;
 
    public GameObject canvas;
    public GameObject panel;
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
            panel.GetComponent<Animator>().SetBool("ended", true);
            Invoke("LoadEndingScene", 2f);
        }
    }


    private void LoadEndingScene()
    {
        SceneManager.LoadScene("EndingScene");
    }
}
