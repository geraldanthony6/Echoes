using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Old Player Movement
public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    private float turnSpeed = 150f;
    private bool playerOnGround = false;
    private bool hasKey = false;

    [SerializeField]private Transform characterWaist;
    [SerializeField]private Transform key1Location;
    [SerializeField]private Transform doorLocation;
    [SerializeField]private float distanceFromKey;
    [SerializeField]private float distanceFromDoor;
    // Update is called once per frame
    void Update()
    {
        PlayerMove();

        PickUpKey();
    }

    void PlayerMove(){
        
        float horizontal = Input.GetAxisRaw("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);  
         
    }

    void PickUpKey(){
        //Checks if key and door are still in scene. If they are do distance calculation, if they're not set both values to 0
        if(key1Location != null && doorLocation != null){
        distanceFromKey = Vector3.Distance(key1Location.position, transform.position);
        distanceFromDoor = Vector3.Distance(doorLocation.position, transform.position);
        } else {
            distanceFromDoor = 0;
            distanceFromKey = 0;
        }
        
        //Attaches key to player on use
        if(distanceFromKey <= 2 && Input.GetKeyDown(KeyCode.F)){
            key1Location.position = characterWaist.position;
            hasKey = true;
        } 
        if(hasKey == true){
            key1Location.position = characterWaist.position;
        }
        
        //Destroys door and key on use
        if(distanceFromDoor <= 5f && hasKey == true && Input.GetKeyDown(KeyCode.F)){
            hasKey = false;
            Destroy(doorLocation.gameObject);
            doorLocation = null;
            Destroy(key1Location.gameObject);
            key1Location = null;
        }
    }
}
