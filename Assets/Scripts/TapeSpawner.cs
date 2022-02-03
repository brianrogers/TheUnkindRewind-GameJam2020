using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeSpawner : MonoBehaviour
{
    public Transform tapeObject;
    public float spawnDelay;
    public int maxTapes;
    private float lastSpawn;
    private int numberOfTapes;

    public bool shouldSpawn;

    // Update is called once per frame
    void Update()
    {
        if (shouldSpawn)
        {
            numberOfTapes = GameObject.FindGameObjectsWithTag("tape").Length;
            if (Time.time >= lastSpawn + spawnDelay && (numberOfTapes < maxTapes))
            {
                Instantiate(tapeObject, new Vector3(0, 0, 0), Quaternion.identity);
                lastSpawn = Time.time;
            }
        }
    }
}
