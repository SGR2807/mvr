using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coll_check : MonoBehaviour
{
    private Vector3 initialManPosition ;
    // private Vector3 initialCarPosition ;

    void Start()
    {
        // Store the initial positions of the "man" and "car" game objects
        initialManPosition = transform.position; // Assuming this script is attached to the "man" object
        // initialCarPosition = GameObject.FindGameObjectWithTag("car").transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the "car" object
        if (collision.gameObject.CompareTag("car"))
        {
            // Reset the positions of the "man" and "car" to their initial positions
            transform.position = initialManPosition;
            // collision.gameObject.transform.position = initialCarPosition;
        }
    }
}