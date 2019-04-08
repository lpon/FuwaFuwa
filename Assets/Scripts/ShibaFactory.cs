using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaFactory : MonoBehaviour
{
    private bool alreadyStarted;

    public GameObject shibaPrefab;
    public AudioSource audioSource;

    public float minSpawnTime;
    public float maxSpawnTime;
    public float offsetBoundary = 1f;
    public float spawnOffset;
    public bool stopped;
    public float fadeTime;


    private void Start()
    {
        alreadyStarted = false;
        stopped = false;
        audioSource.enabled = false;
    }


    public void StartShibaFactory()
    {
        if (!alreadyStarted)
        {
            alreadyStarted = true;
            InvokeRepeating("SpawnShiba", 0f, Random.Range(minSpawnTime, maxSpawnTime));
            audioSource.enabled = true;
        }
    }


    void SpawnShiba()
    {
        if (!stopped)
        {
            Camera cameraMain = Camera.main;
            float rightBoundary = (cameraMain.aspect * cameraMain.orthographicSize) -
                                    offsetBoundary; // width/2
            float leftBoundary = -rightBoundary + offsetBoundary;
            float spawnPoint = cameraMain.transform.position.y + cameraMain.orthographicSize + spawnOffset;

            Vector3 spawnPosition = new Vector3(
                                                Random.Range(leftBoundary, rightBoundary),
                                                spawnPoint,
                                                shibaPrefab.transform.position.z
                                                );

            GameObject newShiba = Instantiate(shibaPrefab, spawnPosition, Quaternion.identity);

            newShiba.GetComponent<Animator>().SetBool("walk", true);
        }
    }

    public void StopShibaFactory()
    {
        stopped = true;
        StartCoroutine(AudioController.FadeOut(audioSource, fadeTime));
    }

}
