using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
         // Get the horizontal and vertical axis inputs.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move the capsule based on the horizontal and vertical inputs.
        transform.position += new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime;
    }
}
