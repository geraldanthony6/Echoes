using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Knight Character Abilities
public class KnightCharacter : MonoBehaviour
{
    [SerializeField] private NewPlayerMovement knightMovment;
    [SerializeField] private GameObject boulder;
    [SerializeField]private GameObject shieldHitBox;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip clip;
    [SerializeField] private GameObject shield;
    [SerializeField]private Transform stonePlacement;
    [SerializeField] private Transform characterShoulder;
    [SerializeField] private Transform shieldEquippedPlacement; 
    [SerializeField] private Transform shieldUnequippedPlacement; 
    [SerializeField]private Vector3 curBoulderPos;
    private float distanceFromBoulder;
    private bool canPickUpBoulder = true;
    private bool boulderInHand = false;
    private bool shieldEquipped = false;

    // Update is called once per frame
    void Update()
    {
        curBoulderPos = boulder.transform.position;
        distanceFromBoulder = Vector3.Distance(transform.position, curBoulderPos);
        PickUpBoulder();
        Shield();
    }

    void PickUpBoulder(){
        if(Input.GetKeyDown(KeyCode.E) && canPickUpBoulder == true && distanceFromBoulder <= 2){
            boulder.transform.position = characterShoulder.position;
            knightMovment.playerSpeed = 3.5f;
            boulderInHand = true;
            canPickUpBoulder = false;
            audioSource.PlayOneShot(clip, 1);
        } else if(Input.GetKeyDown(KeyCode.E) && canPickUpBoulder == false && boulderInHand == true){
            boulder.transform.position = stonePlacement.position;
            knightMovment.playerSpeed = 7f;
            boulderInHand = false;
            canPickUpBoulder = true;
            audioSource.PlayOneShot(clip, 1);
        }

        if(boulderInHand){
        boulder.transform.position = characterShoulder.position;
        }
    }

    void Shield(){
        if(Input.GetKeyDown(KeyCode.Q) && shieldEquipped == false){
            shieldEquipped = true;
            knightMovment.shielding = true;
            shieldHitBox.SetActive(true);
        } else if(Input.GetKeyDown(KeyCode.Q) && shieldEquipped == true){
            shieldEquipped = false;
            knightMovment.shielding = false;
            shieldHitBox.SetActive(false);
        }
        if(shieldEquipped == true){
            shield.transform.position = shieldEquippedPlacement.position;
        } else if(shieldEquipped == false){
            shield.transform.position = shieldUnequippedPlacement.position;
            shield.transform.Rotate(0, 0, 0);
        }
    }
}
