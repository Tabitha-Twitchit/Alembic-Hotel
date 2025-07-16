using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //an array of gameobjects to spawn from, and a range of distances along 2 axes they will spawn
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 10;
    private float spawnRangeZ = 20;

    //does another custom method starting at 2 seconds, then repeats every 1.5 sec
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", 2, 1.5f);
    }

    //creates a random integre between 0 and 2 using the arrays.Length to get the exact num instead of us finding it.
    //then a random range method is used to spawn randomly along the X axis but constrained by our initial floats, and flat with our plane on
    //the Y axis, and at a specific point on our z axis. The prefab is instantiated from the animalIndex at the spawnPos with its 
    //existing rotation.
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
