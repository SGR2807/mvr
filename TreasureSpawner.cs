using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public GameObject objectPrefab; // Assign your object prefab in the Inspector.
    
    private List<GameObject> spawnedObjects = new List<GameObject>();
    public float numberOfBoxes;
    public float remainingObjects;

    void Start()
    {
        SpawnObjects(numberOfBoxes);
    }

    void Update(){
        
    }
    public void SpawnObjects(float numberOfObjects)
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-16f,-3f),
                0.185f,
                Random.Range(-17f, -4f)
            );

            GameObject spawnedObject = Instantiate(objectPrefab, randomPosition, Quaternion.identity);
            spawnedObjects.Add(spawnedObject);
        }
        remainingObjects = numberOfBoxes ;
    }

    public void DestroySpawnedObjects()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }
        spawnedObjects.Clear();
    }
}