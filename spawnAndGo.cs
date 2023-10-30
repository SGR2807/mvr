using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAndGo : MonoBehaviour
{
   public float speed = 5f;
    public float spawnInterval = 5f;
    public float travelDistance = 40f;

    private float distanceTraveled;
    public GameObject newCar;

    void Start()
    {
        timeSinceLastSpawn = 0f;
        
    }

    void Update()
    {
        // Move the car forward.
        Debug.Log(distanceTraveled);
        if (newCar != null)
        {
            transform.position += transform.forward * speed * Time.deltaTime;

            // Keep track of the distance traveled.
            distanceTraveled += speed * Time.deltaTime;

            if (distanceTraveled >= 20f)
            {
                newCar.transform.position = new Vector3(0.54f, 0.26f, 1.22f);
                Vector3 newForward = Quaternion.Euler(0f, -90f, 0f) * Vector3.forward;
                transform.forward = newForward;
                distanceTraveled = 0f;
                
            }
            // Destroy the car if it has traveled the specified distance.
            // if (distanceTraveled >= 20f)
            // {
                
            //    Vector3 newForward = Quaternion.Euler(0f, 180f, 0f) * Vector3.forward;
            //     transform.forward = newForward;
                
            // }
        }

    }
}