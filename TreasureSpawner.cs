using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public GameObject objectPrefab; // Assign your object prefab in the Inspector.
    public float remainingObjects;

    void Start()
    {
        SpawnObjects(8);
    }

    void Update(){
        if(remainingObjects < 2){
            SpawnObjects(8);
        }
    }
    void SpawnObjects(int numberOfObjects)
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-16f,-3f),
                0.185f,
                Random.Range(-17f, -4f)
            );

            Instantiate(objectPrefab, randomPosition, Quaternion.identity);
        }
    }
}