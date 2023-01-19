using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checks if Rogue reaches top of cimbable wall
public class TopOfClimbableWall : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Rogue")){
        Debug.Log("Try Dashing");
        }
    }
}
