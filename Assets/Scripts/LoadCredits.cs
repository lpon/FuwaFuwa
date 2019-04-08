using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCredits : MonoBehaviour
{
    private bool inputRecieved;

    public Animator animator;
    public AudioSource audioSource;
    public float fadeTime;
    

    private void Start()
    {
        inputRecieved = false;
    }


    private void Update()
    {
        if (Input.anyKeyDown && !inputRecieved)
        {
            animator.SetBool("loadCreditScene", true);
            StartCoroutine(AudioController.FadeOut(audioSource, fadeTime));
        }
    }


    private void LoadCreditScene()
    {
        SceneManager.LoadScene("EndCredits");
    }
}
