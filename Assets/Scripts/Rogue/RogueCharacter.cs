using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rogue abilities manager
public class RogueCharacter : MonoBehaviour
{
    //Initialize Variables
    [SerializeField]private NewPlayerMovement rogueMovement;
    [SerializeField]private NewClimbingMovement climbMovement;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip clip;
    [SerializeField]private float dashCoolDown = 0;
    private bool canDash = true;
    private bool dashing = false;
    private float dashTime = 0;
    [SerializeField]private bool canClimb = false;

    // Update is called once per frame
    void Update()
    {
        Dash();
        Climb();

        //Cooldown for dash ability
        if (dashCoolDown > 0){
            dashCoolDown -= Time.deltaTime;
        }
        if(dashCoolDown <= 0){
            canDash = true;
        }        
    }

    //Increases the players movement for a quarter of a second
    void Dash(){
        if(Input.GetKeyDown(KeyCode.E) && dashCoolDown <= 0 && canDash == true){
            dashing = true;
            canDash = false;
            dashCoolDown = 2;
            rogueMovement.playerSpeed = 70;
            audioSource.PlayOneShot(clip, 1);
        }
        if(dashing)
        {
            dashTime += Time.deltaTime;
            if(dashTime >= .25)
            {
                rogueMovement.playerSpeed = 8;
                dashTime = 0;
                dashing = false;
            }
        }
    }

    //Enables climbing movement on key press
    void Climb(){
        if (Input.GetKeyDown(KeyCode.Q) && climbMovement.enabled){
            climbMovement.enabled = false;
            rogueMovement.enabled = true;
        } else if (Input.GetKeyDown(KeyCode.Q) && canClimb == true){
            rogueMovement.enabled = false;
            climbMovement.enabled = true;
        } else if(canClimb == false){
            climbMovement.enabled =false;
            rogueMovement.enabled = true;
        }
    }

    //Checks collisions
    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("ClimbableWall")){
            canClimb = true;
        } 
    }

    //Checks triggers
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("TopOfClimbabaleWall")){
            canClimb = false;
        }
    }
}
