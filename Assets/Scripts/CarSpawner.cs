using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] spawnThings;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    [SerializeField] GameObject carContainer;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }
    void SpawnObject()
    {
        int spawnNumber = (int)Mathf.Floor(Random.Range(0, spawnThings.Length));
        Instantiate(spawnThings[spawnNumber], transform.position, transform.rotation, carContainer.transform);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
