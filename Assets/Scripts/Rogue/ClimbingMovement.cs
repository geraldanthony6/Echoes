using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rogue climbing movement for old player movement
public class ClimbingMovement : MonoBehaviour
{
    private float climbSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        //Stores W and S input in the float vertical
        float vertical = Input.GetAxisRaw("Vertical") * climbSpeed * Time.deltaTime;
        //Moves player
        transform.Translate(Vector3.up * vertical);
    }
}
