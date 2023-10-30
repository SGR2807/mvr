using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAgent : MonoBehaviour
{

    public GameObject agent = null;
    public GameObject car1 = null;
    public GameObject car2 = null;
    // Start is called before the first frame update
    void Start()
    {
        agent.transform.position = new Vector3(10f, 1f, 4f);
        car1.transform.position = new Vector3(0.54f, 0.26f, 1.22f);
        newCar.transform.position = new Vector3(-21.8f, 0.1f, -1.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
