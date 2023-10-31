using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAndGo : MonoBehaviour
{
    public float speed = 14f;
    public float travelDistance = 40f;

    private float distanceTraveled;
    public GameObject newCar;

    void Start()
    {
        
    }

    void Update()
    {
        // Move the car forward.
        if (newCar != null)
        {
            transform.position += transform.forward * speed * Time.deltaTime;

            // Keep track of the distance traveled.
            distanceTraveled += speed * Time.deltaTime;

            if (distanceTraveled >= travelDistance)
            {
                newCar.transform.position = new Vector3(1.8f, 0.56f, -18.4f);
                Vector3 newForward = Quaternion.Euler(0f, 0f, 0f) * Vector3.forward;
                transform.forward = newForward;
                distanceTraveled = 0f;
                
            }
            // Destroy the car if it has traveled the specified distance.
            if (distanceTraveled >= 20f)
            {
               Vector3 newForward = Quaternion.Euler(0f, -90f, 0f) * Vector3.forward;
                transform.forward = newForward;
                
            }
        }

    }
}