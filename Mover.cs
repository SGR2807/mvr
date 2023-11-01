using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;
    public LayerMask pickupLayer;
    private GameObject pickedObject;
    private bool isObjectPicked = false;
    public float pickupDistance = 2f;
    private Vector3 resetPosition;
    public GameObject destinationSpot;
    
    private Rigidbody rb;
    private Vector3 corner1 = new Vector3(-30f , 5f, 5f), 
    corner2 = new Vector3(6.2f , 5f, -30f),
    corner3 = new Vector3(-30f , 5f, -30f), 
     corner4= new Vector3(6.2f , 5f, 5f); 
    private bool once = false;

    public TreasureSpawner treasureSpawner; 


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        resetPosition = transform.position; 
    }
void Update()
    {
        // Player movement
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement =  new Vector3(-1f * horizontalInput, 0f, -1f * verticalInput) * moveSpeed * Time.deltaTime;
        // transform.Translate(movement, Space.Self); 
        rb.velocity = movement * 100f ;


        if(treasureSpawner.remainingObjects < 1){
            
            Debug.Log("Remaining Count of box in if->  " + treasureSpawner.remainingObjects);
            // treasureSpawner.DestroySpawnedObjects();
            // treasureSpawner.SpawnObjects(treasureSpawner.numberOfBoxes);
        }

        // if (IsInsideSquareArea2())
        // {
        //     Debug.Log("in square");
        //     transform.position = resetPosition;
        // }

        // Pick up/drop object
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            Debug.Log("once -> " + once + "   isObjectPicked -> " + isObjectPicked);
            if (!isObjectPicked)
            {
                PickupObject();
                once = false;
            }
            else
            {
                DropObject();
                once = true;
            }
        }
    }

    void PickupObject()
    {
        Debug.Log("In pickup object");
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickupDistance);

        foreach (Collider collider in colliders)
        {
            Debug.Log("colloder name" + collider.tag + " " + collider.tag);
            if (collider.CompareTag("MoneyBox"))
            {
                Debug.Log("MoneyBox tag is matching");
                pickedObject = collider.gameObject;
                pickedObject.GetComponent<Rigidbody>().isKinematic = true;
                pickedObject.transform.parent = transform;
                Vector3 newPosition = pickedObject.transform.position + Vector3.up * 3f;
                pickedObject.transform.position = newPosition;
                isObjectPicked = true;
                break;  
            } else {
                Debug.Log("MoneyBox tag is not matching");
            }
        }
    }

    void DropObject()
    {
        if(pickedObject == null){
            isObjectPicked = false;
            return;
        }
        pickedObject.GetComponent<Rigidbody>().isKinematic = false;
        pickedObject.transform.parent = null;
        Debug.Log("once value -> " + once );
        if( (pickedObject.transform.position.x <= destinationSpot.transform.position.x + 1.4 && 
            pickedObject.transform.position.x >= destinationSpot.transform.position.x - 2) && 
            (pickedObject.transform.position.z <= destinationSpot.transform.position.z + 1.0 && 
            pickedObject.transform.position.z >= destinationSpot.transform.position.z - 2.0) && !once){
                Debug.Log("HEre in if");
                treasureSpawner.remainingObjects--;
                
                Destroy(pickedObject);  
                Debug.Log("Remaining Count of box ->  " + treasureSpawner.remainingObjects);
                // points++;
        }
        Vector3 newPosition = destinationSpot.transform.position ;
        pickedObject.transform.position = newPosition;
        pickedObject = null;
        isObjectPicked = false;
    }

    bool IsInsideSquareArea()
    {
        Vector3 minPoint = Vector3.Min(corner1, Vector3.Min(corner2, Vector3.Min(corner3, corner4)));
        Vector3 maxPoint = Vector3.Max(corner1, Vector3.Max(corner2, Vector3.Max(corner3, corner4)));
        // Debug.Log("inside the function of checking inside");
        return Physics.OverlapBox(
            (minPoint + maxPoint) / 2f, 
            (maxPoint - minPoint) / 2f, 
            Quaternion.identity
        ) != null;
    }
    bool IsInsideSquareArea2()
    {
        // Calculate vectors representing the edges of the square
        Vector3 edge1 = corner2 - corner1;
        Vector3 edge2 = corner3 - corner2;
        Vector3 edge3 = corner4 - corner3;
        Vector3 edge4 = corner1 - corner4;

        // Calculate vectors from the corners to the player's position
        Vector3 toPlayer1 = transform.position - corner1;
        Vector3 toPlayer2 = transform.position - corner2;
        Vector3 toPlayer3 = transform.position - corner3;
        Vector3 toPlayer4 = transform.position - corner4;

        // Check if the player is on the correct side of all four edges
        bool isInside = Vector3.Dot(Vector3.Cross(edge1, toPlayer1), Vector3.Cross(edge1, edge2)) > 0f &&
                        Vector3.Dot(Vector3.Cross(edge2, toPlayer2), Vector3.Cross(edge2, edge3)) > 0f &&
                        Vector3.Dot(Vector3.Cross(edge3, toPlayer3), Vector3.Cross(edge3, edge4)) > 0f &&
                        Vector3.Dot(Vector3.Cross(edge4, toPlayer4), Vector3.Cross(edge4, edge1)) > 0f;

        return isInside;
    }


}