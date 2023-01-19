using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Single door trigger 
//Only one rune/button press required
public class DoorTrigger : MonoBehaviour
{
    [SerializeField] public GameObject door;

    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip clip;

    [SerializeField]private Transform runeLocation;
    [SerializeField]private Transform runeLocation1;
    [SerializeField]private Transform runeLocation2;
    [SerializeField]private Transform runeLocation3;
    [SerializeField]private GameObject runeDoorSingle;
    [SerializeField]private GameObject runeDoorMultiple;
    [SerializeField]private float distanceFromRune;
    [SerializeField]private float distanceFromRune1;
    [SerializeField]private float distanceFromRune2;
    [SerializeField]private float distanceFromRune3;
    [SerializeField]private GameObject runeActivatedLight;
    [SerializeField]private GameObject runeActivatedLight1;
    [SerializeField]private GameObject runeActivatedLight2;
    [SerializeField]private GameObject runeActivatedLight3;
    [SerializeField] private FireballSpawner fireBallSpawner;

    private bool isOpened = false;
    [SerializeField]private int runeCount = 0;

    void Update()
    {
        Mathf.Clamp(runeCount, 1, 3);
        openRuneDoorSingle();
        openDoorRuneMultiple();
    }

    //opens the door as long as a object is on the pressure plate. Door moves up for now can switch to a animation
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Boulder"))
        {
            if (!isOpened)
            {
                door.transform.position += new Vector3(0, 4, 0);
                audioSource.PlayOneShot(clip, 1);
                isOpened = true;
                fireBallSpawner.enabled = false;
            }
        }
        
    }

    //closes the door when nothing is standing on it 
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boulder"))
        {
            if (isOpened)
            {
                door.transform.position -= new Vector3(0, 4, 0);
                isOpened = false;
            }
        }
    }

    void openDoorRuneMultiple(){
        if(runeDoorMultiple != null){
            distanceFromRune1 = Vector3.Distance(runeLocation1.position, transform.position);
            distanceFromRune2 = Vector3.Distance(runeLocation2.position, transform.position);
            distanceFromRune3 = Vector3.Distance(runeLocation3.position, transform.position);
        }

        if(distanceFromRune1 < 2f && Input.GetKeyDown(KeyCode.F) && runeCount == 0){
            runeCount++;
            runeActivatedLight1.SetActive(true);
        }
        if(distanceFromRune2 < 2f && Input.GetKeyDown(KeyCode.F) && runeCount == 1){
            runeCount++;
            runeActivatedLight2.SetActive(true);
        } else if(distanceFromRune2 < 2f && Input.GetKeyDown(KeyCode.F) && runeCount == 0){
            runeActivatedLight1.SetActive(false);
        }
        if(distanceFromRune3 < 2f && Input.GetKeyDown(KeyCode.F) && runeCount == 2){
            runeActivatedLight3.SetActive(true);
            Destroy(runeDoorMultiple);
            audioSource.PlayOneShot(clip, 1);
            runeDoorMultiple = null;
        } else if(distanceFromRune3 < 2f && Input.GetKeyDown(KeyCode.F) && runeCount == 1){
            runeActivatedLight1.SetActive(false);
            runeCount--;
        }
    }

    void openRuneDoorSingle(){
        if(runeDoorSingle != null){
            distanceFromRune = Vector3.Distance(runeLocation.position, transform.position);
        }

        if(distanceFromRune < 2f && Input.GetKeyDown(KeyCode.F)){
            Destroy(runeDoorSingle);
            audioSource.PlayOneShot(clip, 1);
            runeActivatedLight.SetActive(true);
            runeDoorSingle = null;
        }
    }

}
