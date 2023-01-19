using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Climbable wall controller
public class CimbWallInteract : MonoBehaviour
{
    [SerializeField]private GameObject rogue;
    [SerializeField]private float distanceFromRogue;
    [SerializeField]private GameObject interactUI;
    [SerializeField]private bool wallTouched = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rogue = GameObject.FindGameObjectWithTag("Rogue");
        //distanceFromRogue = Vector3.Distance(rogue.transform.position, transform.position);

        if(wallTouched == true){
            interactUI.SetActive(true);
        } else {
            interactUI.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Rogue")){
            wallTouched = true;
        }
    }

    void OnCollisionExit(Collision other){
        if(other.gameObject.CompareTag("Rogue")){
            wallTouched = false;
        }
    }
}
