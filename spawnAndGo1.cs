using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAndGo1 : MonoBehaviour
{
   public float speed = 7f;
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
                newCar.transform.position = new Vector3(-21.8f, 0.62f, -0.62f);
                Vector3 newForward = Quaternion.Euler(0f, 90f, 0f) * Vector3.forward;
                transform.forward = newForward;
                distanceTraveled = 0f;
                
            }
            // Destroy the car if it has traveled the specified distance.
            if (distanceTraveled >= 20f)
            {
               Vector3 newForward = Quaternion.Euler(0f, 180f, 0f) * Vector3.forward;
                transform.forward = newForward;
                
            }
        }

    }
}