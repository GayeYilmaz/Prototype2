using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
   
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    public float sideSpawnMinZ;
    public float sideSpawnMaxZ;
    public float sideSpawnX;

    
    // Start is called before the first frame update
    void Start()
    {
        //Spawn animal after 2 sc from the start of the key and every 1.5 sc
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnRightAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnLeftAnimal", startDelay, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {
        //Sapwn an animal when we press S key
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    SpawnRandomAnimal();
        // }
        
    }

    void SpawnRandomAnimal()
    {
        //Randomly generate animal index and  spwan position
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
      
        //Instatiate the prefabs
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);

    }

    void SpawnLeftAnimal()
    {
        //Randomly generate animal index and  spawn position
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-sideSpawnX, 0, Random.Range(sideSpawnMinZ,sideSpawnMaxZ));

        //Rotate the prefabs rotation
        Vector3 rotation = new Vector3(0, 90, 0);

        //Instatiate the prefabs
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }

    void SpawnRightAnimal()
    {
        //Randomly generate animal index and  spawn position
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));

        //Rotate the prefabs rotation
        Vector3 rotation = new Vector3(0, -90, 0);

        //Instatiate the prefabs
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }


}
