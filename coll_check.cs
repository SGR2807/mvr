// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class coll_check : MonoBehaviour
// {
//     public string scriptNameToRunOnCollision;
//     public GameObject agent = null;

//     private void OnCollisionEnter(Collision collision)
//     {
//         // Get the other object involved in the collision.
//         GameObject otherObject = collision.agent;

//         // Check if the other object has the same tag as this object.
        
//         if (otherObject.tag == agent.tag)
//         {
//             // Get the script component of the new script to run.
//             spawnAgent scriptComponent = otherObject.GetComponent<spawnAgent>();

//             // If the script component is not null, run the script.
//             if (scriptComponent != null)
//             {
//                 scriptComponent.RunScript();
//             }
//         }
//     }
// }