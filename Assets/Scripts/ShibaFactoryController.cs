using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaFactoryController : MonoBehaviour
{
    private bool alreadyStarted;

    public GameObject shibaPrefab;
    public float minSpawnTime;
    public float maxSpawnTime;
    public float offsetBoundary = 1f;
    public float spawnOffset;


    private void Start()
    {
        alreadyStarted = false;
    }


    // Start is called before the first frame update
    public void StartShibaFactory()
    {
        if (!alreadyStarted)
        {
            alreadyStarted = true;
            InvokeRepeating("SpawnShiba", 0f, Random.Range(minSpawnTime, maxSpawnTime));
        }
    }


    void SpawnShiba()
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
