using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rogue climbing Movement for new player movement
public class NewClimbingMovement : MonoBehaviour
{
    private float climbSpeed = 3f;
    public CharacterController controller;
    // Update is called once per frame
    void Update()
    {
        //Stores W and S input in the float vertical
        float vertical = Input.GetAxisRaw("Vertical") * climbSpeed * Time.deltaTime;
        //Moves player
        controller.Move(Vector3.up * vertical);
    }
}
