using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coll_check : MonoBehaviour
{
    private Vector3 initialManPosition ;
    // private Vector3 initialCarPosition ;

    public TreasureSpawner treasureSpawner; 

    void Start()
    {
        initialManPosition = transform.position; 
        // initialCarPosition = GameObject.FindGameObjectWithTag("car").transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("car"))
        {
            transform.position = initialManPosition;
            treasureSpawner.DestroySpawnedObjects();
            treasureSpawner.SpawnObjects(treasureSpawner.numberOfBoxes);
            treasureSpawner.remainingObjects = treasureSpawner.numberOfBoxes;
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            // collision.gameObject.transform.position = initialCarPosition;
        }
    }
}